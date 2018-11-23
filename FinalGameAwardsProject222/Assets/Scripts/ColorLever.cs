using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLever : Interactable {

    [SerializeField] PhotonView photonView;
    Animator anim;

    public string StringToAdd;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }


    public override void Interact()
    {
        base.Interact();
        photonView.RPC("SetLeverAnim", PhotonTargets.All);
    }

   [PunRPC]
   void SetLeverAnim()
   {
       anim.SetTrigger("Use");
   }
}
