using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ServerBrowserContainer : MonoBehaviour {

    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Button joinButton;
	
	void Start ()
    {
        Debug.Log("Created");
	}
	
	void Update ()
    {
        SetText(PhotonNetwork.GetRoomList()[0].Name);
	}
    public void SetText(string _serverName)
    {
        nameText.text = _serverName;
        joinButton.onClick.AddListener(Join);
    }

    public void Join()
    {
        FindObjectOfType<PhotonNetworkManager>().JoinRoom2(nameText.text);
    }
    
}
