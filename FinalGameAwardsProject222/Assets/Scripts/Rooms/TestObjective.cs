using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObjective : Objective {
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.O))
        {
            Complete();
        }
	}
}
