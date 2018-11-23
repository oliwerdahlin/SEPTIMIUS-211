using UnityEngine;


[CreateAssetMenu(fileName = "Room", menuName = "ScriptableObjects/Room")]
public class PuzzleRoom : ScriptableObject {


    public string roomName;
    public Objective[] goals;



    public bool AllGoalsCompleted()
    {
        for (int i = 0; i < goals.Length; i++)
        {
            if(!goals[i].Completed)
            {
                return false;
            }
        }
        return true;
    }
}

