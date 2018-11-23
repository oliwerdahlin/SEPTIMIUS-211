using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interactable
{
    [SerializeField] Transform mirrorToRotate;

    PhotonView photonView;

	void Start ()
    {
        photonView = GetComponent<PhotonView>();
	}

    public override void Interact()
    {
        base.Interact();
        StartToggleRotation();
    }

    public void StartToggleRotation()
    {
        photonView.RPC("Rotate", PhotonTargets.All);
    }

    [PunRPC]
    void Rotate()
    {
        mirrorToRotate.Rotate(new Vector3(0, 45, 0));
    }

}
