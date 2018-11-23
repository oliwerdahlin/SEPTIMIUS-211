using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Datapad : Interactable
{
    [SerializeField] TextAsset textToAdd;
    public GameObject logObject;
    PhotonView photonView;


    bool interacted = false;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    public override void Interact()
    {
        base.Interact();
        if(!interacted)
        {
            photonView.RPC("AddLogToMenu", PhotonTargets.All);
            interacted = true;
        }
        //DatapadManager.Instance.AddNewText(textToAdd);
    }

    [PunRPC]
    void AddLogToMenu()
    {
        GameObject log = Instantiate(logObject, DatapadManager.Instance.logContent.transform);
       // log.transform.parent = DatapadManager.Instance.logContent.transform;
    }
}

