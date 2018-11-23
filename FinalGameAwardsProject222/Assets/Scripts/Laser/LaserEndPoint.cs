using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEndPoint : Objective {

    private void Start()
    {
        gameObject.layer = 10;
    }

    public void Hit()
    {
        Complete();
    }
}
