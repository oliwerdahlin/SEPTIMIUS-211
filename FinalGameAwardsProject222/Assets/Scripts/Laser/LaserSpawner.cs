using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour {

    PhotonView photonView;

    [SerializeField] GameObject laserObject;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
        //SpawnLaser();
    }
    [PunRPC]
    public void SpawnLaser()
    {
        // photonView.RPC("Laser", PhotonTargets.All);
        PhotonNetwork.Instantiate(laserObject.name, transform.position, transform.rotation, 0);
    }
}
