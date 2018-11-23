using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonObjective : Objective {

    bool pressedDown = false;



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<PickupableObject>() != null)
        {
            if(other.gameObject.GetComponent<PickupableObject>().pickupType == PickupType.Weight)
            {
                pressedDown = true;
                Complete();
                this.GetComponent<MeshRenderer>().material.color = Color.green;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<PickupableObject>() != null)
        {
            if (other.gameObject.GetComponent<PickupableObject>().pickupType == PickupType.Weight)
            {
                pressedDown = false;
                UnComplete();
                this.GetComponent<MeshRenderer>().material.color = Color.red;

            }
        }
    }
}
