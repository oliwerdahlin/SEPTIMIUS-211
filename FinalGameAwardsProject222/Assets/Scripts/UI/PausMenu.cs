using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class PausMenu : MonoBehaviour {

    public GameObject menu;
    public GameObject LobbyCanvas;
    //bool LobbyCanvas;
    PhotonView photonView;
    // private GameObject LobbyCanvas;

    bool isEnabled = false;
    bool LB = false;

    public FinRoomManager roomManager;


    
    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        LobbyCanvas = GameObject.FindGameObjectWithTag("LobbyCanvasTag");

        //menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

           
            if (Input.GetKeyDown(KeyCode.Escape)/* && LB == false*/)
            {

                if (isEnabled == false /*&& LB == false*/&& LobbyCanvas.activeSelf == false && MenuManager.instance.MenusActive() == false && MenuManager.instance.menusCanBeEnabled == true)
                {

                    menu.SetActive(true);
                    isEnabled = true;
                    foreach (GameObject p in roomManager.players)
                    {
                        p.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
                        p.GetComponent<FirstPersonController>().m_RunSpeed = 0;
                        p.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                        p.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                        p.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;

                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                    }
                    return;

                }
                if (isEnabled == true  /* && LB == true*//*&& LobbyCanvas.activeSelf == true*/)
                {
                    isEnabled = false;
                    menu.SetActive(false);
                    foreach (GameObject p in roomManager.players)
                    {
                        p.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
                        p.GetComponent<FirstPersonController>().m_RunSpeed = 8;
                        p.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
                        p.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
                        p.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;

                        Cursor.lockState = CursorLockMode.Locked;
                        Cursor.visible = false;
                    }
                     
                }
            }
        }   
   // }

    public void LeaveGame()
    {
        photonView.RPC("LeaveGame1", PhotonTargets.All);
    }

    [PunRPC]
    void LeaveGame1()
    {
        //roomManager.players.Clear();

        PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);

        PhotonNetwork.LeaveRoom();
    }

    void OnLeftRoom()
    {
        SceneManager.LoadScene(0);

    }
}
