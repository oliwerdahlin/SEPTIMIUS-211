using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingTest : MonoBehaviour {

    PhotonView photonView;

	// Use this for initialization
	void Start () {
        photonView = GetComponent<PhotonView>();
        PhotonNetwork.automaticallySyncScene = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.G))
        {
            photonView.RPC("LoadScene", PhotonTargets.All);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            photonView.RPC("UnloadScene", PhotonTargets.All);
        }
	}

    [PunRPC]
    void LoadScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    [PunRPC]
    void UnloadScene()
    {
        SceneManager.UnloadSceneAsync(0);
    }
}
