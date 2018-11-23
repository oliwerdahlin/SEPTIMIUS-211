using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class LaserHost : MonoBehaviour {


    [SerializeField] LayerMask collisionMask;
    [SerializeField] LayerMask destroyMask;
    [SerializeField] LayerMask endPointMask;
    [SerializeField] float speed = 5f;

    [SerializeField] Animator[] doors;


    [SerializeField] Transform pool;


    PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        photonView.RPC("EnableTrail", PhotonTargets.All);
        Debug.Log("Spawned laser");
    }


    // Update is called once per frame
    void Update()
    {
        Bounce();
       // photonView.RPC("Bounce", PhotonTargets.All);
    }

    [PunRPC]
    void EnableTrail()
    {
        GetComponent<TrailRenderer>().enabled = true;
    }

    [PunRPC]
    void OpenDoors()
    {
        foreach(Animator a in doors)
        {
            a.SetTrigger("Open");
        }
    }

    private void OnDestroy()
    {
        Debug.Log("laser destroyed");
        GetComponent<TrailRenderer>().time = 2f;
    }

    //[PunRPC]
    void Bounce()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + 0.1f, collisionMask))
        {
            Vector3 reflectDir = Vector3.Reflect(ray.direction, hit.normal);
            float rot = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, rot, 0);
        }
        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + 0.1f, destroyMask))
        {
            PhotonNetwork.Destroy(this.gameObject);
        }
        if (Physics.Raycast(ray, out hit, Time.deltaTime * speed + 0.1f, endPointMask))
        {
            hit.transform.gameObject.GetComponent<LaserEndPoint>().Hit();
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
