using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AuraAPI;

public class GameManager : MonoBehaviour {

    [SerializeField] GameObject player;

    [SerializeField] Transform[] spawnPoints;

    

    AuraLight[] volumetricLights;
    bool hasEnabledLights = false;
	void Start ()
    {

        DontDestroyOnLoad(this.gameObject);

        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            PhotonNetwork.Instantiate(player.name, spawnPoints[i].position, spawnPoints[i].rotation, 0);
        }

        
	}
	
	void Update () {
		if(PhotonNetwork.playerList.Length > 0 && !hasEnabledLights)
        {
            volumetricLights = FindObjectsOfType<AuraLight>();
            for (int i = 0; i < volumetricLights.Length; i++)
            {
                volumetricLights[i].enabled = true;
            }
        }
    }
}
