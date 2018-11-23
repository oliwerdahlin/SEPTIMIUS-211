using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;


public class KeypadObjective : Objective {

    public GameObject keypadCanvas;

    public string correctCombination;

    public string currentCombination;

    Keypad keypad;

    private void Start()
    {
        this.gameObject.tag = "Keypad";
        //keypadCanvas = GameObject.FindGameObjectWithTag("KeypadCanvas");
        keypad = keypadCanvas.GetComponent<Keypad>();
        keypadCanvas.SetActive(false);
    }

    private void FixedUpdate()
    {
        currentCombination = keypad.combination;
        if(currentCombination == correctCombination)
        {
            Complete();
            keypad.combination = string.Empty;
        }
    }

    public void SetCanvas(bool state)
    {
        keypadCanvas.SetActive(state);
        if(state == true)
        {
            FindObjectOfType<FirstPersonController>().m_WalkSpeed = 0;
            FindObjectOfType<FirstPersonController>().m_RunSpeed = 0;
            FindObjectOfType<FirstPersonController>().m_MouseLook.XSensitivity = 0;
            FindObjectOfType<FirstPersonController>().m_MouseLook.YSensitivity = 0;
            FindObjectOfType<FirstPersonController>().m_MouseLook.lockCursor = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (state == false)
        {
            FindObjectOfType<FirstPersonController>().m_WalkSpeed = 5;
            FindObjectOfType<FirstPersonController>().m_RunSpeed = 8;
            FindObjectOfType<FirstPersonController>().m_MouseLook.XSensitivity = 2;
            FindObjectOfType<FirstPersonController>().m_MouseLook.YSensitivity = 2;
            FindObjectOfType<FirstPersonController>().m_MouseLook.lockCursor = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }



    }


}
