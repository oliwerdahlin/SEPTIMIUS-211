using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter2 : MonoBehaviour {

    public GameObject teleportedObject;

    float disableTimer = 2f;

    public Transform pointToTeleportTo;

    public FinRoomManager roomManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.GetComponent<PickupableObject>() != null)
        {
            other.transform.parent = null;
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.position = pointToTeleportTo.position;
           // other.transform.GetComponent<>

            foreach(GameObject p in roomManager.players)
            {
                p.GetComponentInChildren<PlayerInteract>().carriedObject = null;
                p.GetComponentInChildren<PlayerInteract>().carryingObject = false;

            }
        }
    }
}
