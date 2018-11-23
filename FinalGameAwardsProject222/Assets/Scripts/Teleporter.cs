using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public int index;
    float disableTimer = 2;

    PhotonView photonView;

    GameObject objToTeleport;
    Vector3 positionToTeleportTo;

    public GameObject pickupableObjectPrefab;

    private FinRoomManager roomManager;

    private void Start()
    {
        roomManager = FindObjectOfType<FinRoomManager>();
        photonView = GetComponent<PhotonView>();
    }


    private void Update()
    {
        if (disableTimer > 0)
            disableTimer -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider Obj)
    {
        
        if (Obj.gameObject.GetComponent<PickupableObject>() != null && disableTimer <=0)
        {
            foreach(Teleporter tp in FindObjectsOfType<Teleporter>())
            {
                if(tp.index==index && tp != this && Obj.GetComponent<PickupableObject>().canBeTeleported)
                {
                    //Obj.GetComponent<Rigidbody>().isKinematic = false;
                    Obj.transform.parent = null;
                    tp.disableTimer = 5f;
                    Vector3 position = tp.gameObject.transform.position;
                    position.y += 1;
                    positionToTeleportTo = position;

                    //Obj.transform.position = position;

                    objToTeleport = Obj.gameObject;
                    GameObject objectToDestroy =  PhotonNetwork.Instantiate(pickupableObjectPrefab.name, position, tp.gameObject.transform.rotation, 0);
                    PhotonNetwork.Destroy(Obj.gameObject);
                    Destroy(Obj.gameObject);
                    Destroy(objectToDestroy);
                    photonView.RPC("Teleport", PhotonTargets.All);
                    photonView.RPC("RemoveCarriedObjects", PhotonTargets.All);
                }

            }
        }
    }

    [PunRPC]
    public void Teleport()
    {
       // Debug.Log("Teleport");
       // objToTeleport.transform.position = positionToTeleportTo;
        objToTeleport = null;
    }

    [PunRPC]
    public void RemoveCarriedObjects()
    {

        foreach (GameObject p in roomManager.players)
        {

            Debug.LogWarning("Removing carried objects");
            p.GetComponentInChildren<PlayerInteract>().carriedObject = null;
            Debug.LogWarning("Removing carried objects1");
            p.GetComponentInChildren<PlayerInteract>().carryingObject = false;

        }
    }
}
