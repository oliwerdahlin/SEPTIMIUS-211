using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotonNetworkManager : Photon.MonoBehaviour
{
   // [SerializeField] private Text connectText;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject lobbyCamera;
    [SerializeField] private GameObject playScreen;
   // [SerializeField] private GameObject waitingScreen;
    [SerializeField] private InputField inputFieldCreate;
    [SerializeField] private InputField inputFieldPlay;
    [SerializeField] private RoomOptions roomOptions;
    [SerializeField] private GameObject menuScreen;

    [SerializeField] private TextMeshProUGUI playersText;

    GameObject player1;
    GameObject player2;

    Transform spawnpoint1;
    Transform spawnpoint2;

    // [SerializeField] private GameObject roomCreateScreen;
    //  [SerializeField] private TMP_InputField usernameInputfield;

    // [SerializeField] private GameObject usernameContainerUI;
    // [SerializeField] private Transform usernameParent;

    // [SerializeField] private GameObject 

    //List<string> usernames = new List<string>();

    // PhotonView photonView;


    // Use this for initialization
    void Start ()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
        roomOptions.MaxPlayers = 2;
        //photonView = GetComponent<PhotonView>();
	}

    public virtual void OnJoinedLobby()
    {
        Debug.Log("CONNECTED");
        //Join Room if it exists or create a room.
       // PhotonNetwork.JoinOrCreateRoom("Test", null, null);
    }

    public virtual void OnJoinedRoom()
    {

        spawnpoint1 = GameObject.FindGameObjectWithTag("MainSpawnPoint1").transform;
        spawnpoint2 = GameObject.FindGameObjectWithTag("MainSpawnPoint2").transform;

        if (PhotonNetwork.playerList.Length == 1)
        {
            PhotonNetwork.Instantiate(player.name, spawnpoint1.position, spawnpoint1.rotation, 0);
            menuScreen.SetActive(false);
            FindObjectOfType<FinRoomManager>().GetPlayers1();

            // waitingScreen.SetActive(true);


        }
        if (PhotonNetwork.playerList.Length == 2)
        {
            PhotonNetwork.Instantiate(player.name, spawnpoint2.position, spawnpoint2.rotation, 0);
            menuScreen.SetActive(false);
            //waitingScreen.SetActive(false);
            FindObjectOfType<FinRoomManager>().GetPlayers1();
        }

        //Spawn player.
        //Disable lobby camera.
        lobbyCamera.SetActive(false);
    }

   //private void Update()
   //{
   //    playersText.text = "Players: " + PhotonNetwork.playerList.Length.ToString() + " / 2";
   //}

    // Update is called once per frame
    ///void Update ()
    ///{ //
    ///  //f(PhotonNetwork.playerList.Length == 1)
    ///  //{
    ///  //    
    ///  //}
    ///
    //}

    public void StartGame()
    {

       // menuScreen.SetActive(false);
       //
       // if (PhotonNetwork.playerList.Length == 1)
       // {
       //     PhotonNetwork.Instantiate(player.name, spawnPoints[0].position, spawnPoints[0].rotation, 0);
       //     PhotonNetwork.Instantiate(player.name, spawnPoints[1].position, spawnPoints[1].rotation, 0);
       // 
       // 
       // }

        PhotonNetwork.CreateRoom("1");
    }

    public void OnClickedPlayButton()
    {
        playScreen.SetActive(true);
    }

   //public void OnEnteredName()
   //{
   //    roomCreateScreen.SetActive(true);
   //    photonView.RPC("AddName", PhotonTargets.All);
   //    playScreen.SetActive(false);
   //
   //}

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(inputFieldCreate.text, roomOptions, null);
    }
    public void JoinRoom1()
    {
        PhotonNetwork.JoinRoom(inputFieldPlay.text);
    }

    public void JoinRoom2(string _name)
    {
        PhotonNetwork.JoinRoom(_name);
    }

   //public void DisableGameObject()
   //{
   //    usernameContainerUI.SetActive(false);
   //}

    //[PunRPC]
    //void AddName()
    //{
    //    usernames.Add(usernameInputfield.text);
    //    for (int i = 0; i < usernames.Count; i++)
    //    {
    //        GameObject usernameInstance = PhotonNetwork.Instantiate("usernameContainer", usernameParent.position, usernameParent.rotation, 0);
    //        usernameInstance.GetComponentInChildren<TextMeshProUGUI>().text = usernames[i];
    //    }
    //   
    //}

}
