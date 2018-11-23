using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour {

    public Objective objective;

    public float disableTimer;

    MeshRenderer renderer;
    Collider collider;

    PhotonView photonView;

	// Use this for initialization
	void Start ()
    {
        photonView = GetComponent<PhotonView>();
        collider = GetComponent<Collider>();
        renderer = GetComponent<MeshRenderer>();
	}

    private void FixedUpdate()
    {
        if(objective.Completed)
        {
            StartCoroutine(Disable());
        }
    }

    IEnumerator Disable()
    {
        photonView.RPC("DisableForceField",PhotonTargets.All);
        yield return new WaitForSeconds(disableTimer);
        photonView.RPC("EnableForceField", PhotonTargets.All);
    }

    [PunRPC]
    void DisableForceField()
    {
        renderer.enabled = false;
        collider.enabled = false;
    }

    [PunRPC]
    void EnableForceField()
    {
        objective.UnComplete();
        renderer.enabled = true;
        renderer.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Colliding");

        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(25);
        }
    }
}
