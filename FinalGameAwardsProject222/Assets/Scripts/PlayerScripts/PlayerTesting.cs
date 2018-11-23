using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTesting : MonoBehaviour {

    [SerializeField] string newCorrectID;
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.T))
        {
            FindObjectOfType<RoomController>().ChangeCorrectID(newCorrectID);
        }
	}
}
