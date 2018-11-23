using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockRoomController : MonoBehaviour {

    public string correctCombination;
    public string correctCombination2;
    [SerializeField] Animator[] doors;
    [SerializeField] PhotonView photonView;
    [SerializeField] Color newAmbientColor;




    public void CompleteRoom()
    {
        photonView.RPC("OpenDoors", PhotonTargets.All);
    }

    [PunRPC]
    void OpenDoors()
    {
        foreach (Animator a in doors)
        {
            a.SetTrigger("Open");
            RenderSettings.ambientLight = newAmbientColor;
        }
    }

    [PunRPC]
    void SetColorAmbient()
    {

    }
}
