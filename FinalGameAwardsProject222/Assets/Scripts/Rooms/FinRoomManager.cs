using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinRoomManager : MonoBehaviour {

    private PuzzleRoom room;
    public Animator[] doors;

    public bool testOpening = false;

    public GameObject ob;

    public GameObject[] players;

    public PhotonView photonView;

    public RoomObjectives[] roomObjectives;

    //public List<GameObject[]> spawnPoints = new List<GameObject[]>();

    private Objective[] objectives;

    public int roomIndex = 0;

    public static FinRoomManager instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start ()
    {
        room = roomObjectives[roomIndex].room;


        room.goals = roomObjectives[roomIndex].objectives;

        for (int i = 0; i < room.goals.Length; i++)
        {
            room.goals[i].Completed = false;
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(room.AllGoalsCompleted())
        {
            photonView.RPC("OpenDoors", PhotonTargets.All);
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            photonView.RPC("CompleteGoal", PhotonTargets.All);
        }

        foreach(GameObject player in players)
        {
            if(player.GetComponent<PlayerHealth>().isDead)
            {
                photonView.RPC("RespawnPlayers", PhotonTargets.All);
            }
        }
        
	}
    public void GetPlayers1()
    {
        photonView.RPC("GetPlayers",PhotonTargets.All);
    }

    [PunRPC]
    void GetPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    [PunRPC]
    public void OpenDoors()
    {
        if(testOpening)
        {
            Destroy(roomObjectives[roomIndex].door);
            roomIndex++;
            Debug.Log("All goals completed.");
            GetComponent<AudioSource>().Play();
        }
        else
        {
            foreach (Animator a in doors)
            {
                a.SetTrigger("Open");
            }
            GetComponent<AudioSource>().Play();

        }
        Debug.Log("All goals completed.");       
    }

    [PunRPC]
    public void CompleteGoal()
    {

        Debug.Log("Completed objective");

        for (int i = 0; i < room.goals.Length; i++)
        {
            if (room.goals[i].Completed == false)
            {
                room.goals[i].Completed = true;
                break;
            }
        }
    }

    [PunRPC]
    public void RespawnPlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerHealth>().Respawn(roomObjectives[roomIndex].spawnpoints[i].transform);
        }
    }
}
