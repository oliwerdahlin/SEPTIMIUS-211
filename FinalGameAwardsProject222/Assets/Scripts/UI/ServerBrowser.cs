using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerBrowser : MonoBehaviour {

    public GameObject serverBrowserElement;
    public Transform serverBrowserContent;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //FetchServers();
	}

    public void FetchServers()
    {
        foreach(Transform t in serverBrowserContent.transform)
        {
            if(t != serverBrowserContent)
            {
                Destroy(t.gameObject);
            }
        }
        RoomInfo[] availableServers = PhotonNetwork.GetRoomList();
        for (int i = 0; i < availableServers.Length; i++)
        {
            GameObject newEntry = Instantiate(serverBrowserElement, serverBrowserContent);
            newEntry.GetComponent<ServerEntry>().serverName = availableServers[i].Name;
            newEntry.GetComponent<ServerEntry>().players = availableServers[i].PlayerCount;
            //newEntry.GetComponent<ServerEntry>().ping = availableServers[i].
        }
    }
}
