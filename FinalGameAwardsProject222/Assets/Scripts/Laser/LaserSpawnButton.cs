using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawnButton : Interactable
{

    public GameObject laserObject;

    PhotonView photonView;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    public override void Interact()
    {
        Debug.Log("Interacting with button.");
        base.Interact();
        photonView.RPC("SpawnLaser", PhotonTargets.All);
    }

    [PunRPC]
    public void SpawnLaser()
    {
        // photonView.RPC("Laser", PhotonTargets.All);
        PhotonNetwork.Instantiate(laserObject.name, transform.position, transform.rotation, 0);
    }

}
