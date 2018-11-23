using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour {

    [SerializeField] GameObject waitScreen;
    [SerializeField] TextMeshProUGUI textMesh;


    private void Start()
    {
        waitScreen.SetActive(false);
    }
    // Update is called once per frame
    void Update ()
    {
        //if(PhotonNetwork.playerList.Length == 2)
        //{
        //    waitScreen.SetActive(false);
        //}
        textMesh.text = "Players: " + PhotonNetwork.playerList.Length.ToString() + " / 2";
    }

  
}
