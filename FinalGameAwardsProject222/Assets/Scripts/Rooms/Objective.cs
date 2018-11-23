using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {


    public bool Completed = false;


	public virtual void Complete()
    {
        Completed = true;
        Debug.Log("Objective Completed");
    }

    public virtual void UnComplete()
    {
        Completed = false;
    }
}
