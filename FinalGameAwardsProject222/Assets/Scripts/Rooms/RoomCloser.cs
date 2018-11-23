using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCloser : MonoBehaviour {

    [SerializeField] Animator anim;
    [SerializeField] PhotonView photonView;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            photonView.RPC("SetAnim", PhotonTargets.All);
        }
    }

    [PunRPC]
    void SetAnim()
    {
        anim.SetTrigger("Close");
    }
}
