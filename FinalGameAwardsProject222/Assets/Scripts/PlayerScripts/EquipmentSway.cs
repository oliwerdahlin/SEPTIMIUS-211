using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSway : MonoBehaviour {

    float mouseX;
    float mouseY;

    Quaternion rotationSpeed;

    public float speed;
	
	// Update is called once per frame
	void Update ()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        rotationSpeed = Quaternion.Euler(-mouseX, mouseY, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, rotationSpeed, speed * Time.deltaTime);
	}
}
