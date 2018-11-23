using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ServerEntry : MonoBehaviour {


    public TextMeshProUGUI serverNameText;
    public TextMeshProUGUI playersText;


    public string serverName;
    public int players;
	// Use this for initialization
	void Start ()
    {
        serverNameText.text = serverName;
        playersText.text = players.ToString() + "/2";
	}

    public void ClickedJoinButton()
    {
        PhotonNetwork.JoinRoom(serverName);
    }
}
