using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirLockRoomPlayer : MonoBehaviour {


    string currentCombo;
    [SerializeField] AirlockRoomController roomController;
    [SerializeField] float timeToLive;

	void Start ()
    {
        roomController = FindObjectOfType<AirlockRoomController>();
	}
	
	void Update ()
    {
        if (currentCombo != string.Empty)
        {


            if (currentCombo == roomController.correctCombination)
            {
                roomController.CompleteRoom();
            }
            if (currentCombo == roomController.correctCombination2)
            {
                roomController.CompleteRoom();
            }


            if (currentCombo.Length == 2 && currentCombo != roomController.correctCombination && currentCombo != roomController.correctCombination2)
            {
                currentCombo = string.Empty;
            }

        } 
	}

  // IEnumerator DeathTimer()
  // {
  //     yield return new WaitForSeconds(timeToLive);
  //     Destroy(gameObject);
  // }

    public void AddToCurrent(string toAdd)
    {
        currentCombo += toAdd;
    }
}
