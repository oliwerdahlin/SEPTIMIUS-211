using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoomController : MonoBehaviour {

    public string correctID;
    [SerializeField] Text testText;
    [SerializeField] PhotonView photonView;

    [SerializeField] GameObject[] players;
    [SerializeField] Animator[] doors;

    [SerializeField] TextMeshPro text;
	// Update is called once per frame
	void Update ()
    {

        //if(PhotonNetwork.playerList.Length == 1)
        //{
        //    testText = GameObject.FindGameObjectWithTag("TestText1").GetComponent<Text>();
        //}

        if(testText != null)
        {
            testText.text = correctID;
        }

        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public void ChangeCorrectID(string _correctID)
    {
        correctID = _correctID;
    }

    private void Start()
    {
        photonView.RPC("SetText", PhotonTargets.All);
    }
    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.isWriting)
        {
            //Send data.
            if(correctID != string.Empty)
            {
                stream.SendNext(correctID);
            }
        }

        else if(stream.isReading)
        {
            correctID = (string)stream.ReceiveNext();
            Debug.Log("Recieved");
        }
    }

    public void CompleteRoom()
    {
        photonView.RPC("NetworkDestroy", PhotonTargets.All);
    }

    [PunRPC]
    void NetworkDestroy()
    {
        foreach (Animator a in doors)
        {
            a.SetTrigger("Open");
        }
    }

    [PunRPC]
    void SetText()
    {
        text.text = correctID;

    }

}
