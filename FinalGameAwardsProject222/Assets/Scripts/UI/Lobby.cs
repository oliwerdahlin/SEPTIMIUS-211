using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : MonoBehaviour {

    [SerializeField] GameObject serverContainer;

    [SerializeField] Transform serverBrowserparent;
	
	void Start ()
    {
		
	}
	
	void Update ()
    {
		foreach(RoomInfo info in PhotonNetwork.GetRoomList())
        {
            Debug.Log(info.Name);
            GameObject serverBrowserObjectInstance = PhotonNetwork.InstantiateSceneObject(serverContainer.name, Vector3.zero, Quaternion.identity, 0, null);
            serverBrowserObjectInstance.transform.SetParent(serverBrowserparent);
            serverBrowserObjectInstance.GetComponent<ServerBrowserContainer>().SetText(info.Name);
        }
	}
}
