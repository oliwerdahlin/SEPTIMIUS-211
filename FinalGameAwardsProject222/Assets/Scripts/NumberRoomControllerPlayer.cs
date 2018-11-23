using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberRoomControllerPlayer : MonoBehaviour {

    [SerializeField] string correctCombo;
    [SerializeField] string currentCombo;

    [SerializeField] Text currenComboText;



    public int currentRoomIndex;

    [SerializeField] FinRoomManager[] rooms;


    // Use this for initialization

    private void Start()
    {
       
    }

    // Update is called once per frame
    //void Update ()
    //{
    //    if(currentCombo == rooms[currentRoomIndex].correctCombination)
    //    {
    //        rooms[currentRoomIndex].CompleteGoal();
    //        currentCombo = string.Empty;
    //    }
	//}

    public void AddToCurrentCombo(string charactersToAdd)
    {
        currentCombo += charactersToAdd;
    }

   //private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
   //{
   //    Debug.Log("OnPhotonSerializeView");
   //    if(stream.isWriting && currentCombo != string.Empty)
   //    {
   //        stream.SendNext(currentCombo);
   //    }
   //
   //    else if(stream.isReading)
   //    {
   //        currentCombo = (string)stream.ReceiveNext();
   //    }
   //}
}
