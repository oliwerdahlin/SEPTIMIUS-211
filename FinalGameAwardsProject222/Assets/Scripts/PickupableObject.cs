using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour {

    Rigidbody rb;

    bool beingCarried = false;

    public bool canBeTeleported = false;

    PhotonView photonView;

    public PickupType pickupType;

    Transform player;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        photonView = GetComponent<PhotonView>();
	}
	
	

    [PunRPC]
    void Pickup1()
    {
        beingCarried = true;
        rb.isKinematic = true;

       // transform.parent = player;
        //transform.localPosition = new Vector3(0, 0, 2f);
        player = null;

        canBeTeleported = true;
    }

    public void Pickup()
    {
        photonView.RPC("Pickup1", PhotonTargets.All);
    }
    [PunRPC]
    public void Drop()
    {
        //player = null;
        beingCarried = false;
        rb.isKinematic = false;
        transform.parent = null;
    }

    public void Drop1()
    {
        photonView.RPC("Drop",PhotonTargets.All);
        //Drop();
    }


    public void SetRigidbody1()
    {
        photonView.RPC("SetRigidBody", PhotonTargets.All);
    }

    [PunRPC]
    public void SetRigidBody()
    {
        rb.isKinematic = true;
    }
}
public enum PickupType { Weight, PowerSource}
