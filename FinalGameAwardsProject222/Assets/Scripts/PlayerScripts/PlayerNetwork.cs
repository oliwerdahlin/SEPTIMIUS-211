using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PlayerNetwork : MonoBehaviour
{
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private MonoBehaviour[] playerControlledScripts;

    public FinRoomManager roomManager;

    private GameObject playerUIInstance;
    private PhotonView photonView;

    public Image cursor;

    private void Start()
    {
        photonView = GetComponent<PhotonView>();
        Initialize();
        roomManager = FindObjectOfType<FinRoomManager>();
        roomManager.GetPlayers1();
    }

    void Initialize()
    {
        if(photonView.isMine)
        {
            playerUIInstance = Instantiate(playerUI);
            cursor = playerUIInstance.GetComponentInChildren<Image>();
            //GetComponent<NumberRoomControllerPlayer>().GetText();
        }
        else
        {
            playerCamera.GetComponent<Camera>().enabled = false;
            playerCamera.GetComponent<AudioListener>().enabled = false;
           //foreach(AudioListener a in FindObjectsOfType<AudioListener>())
           //{
           //    a.enabled = false;
           //}
            foreach(MonoBehaviour m in playerControlledScripts)
            {
                m.enabled = false;
            }
        }
    }
}
