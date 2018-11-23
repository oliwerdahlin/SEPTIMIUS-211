using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class Keypad : MonoBehaviour {

    public string combination;

    public TextMeshProUGUI combinationText;

    public FinRoomManager roomManager;

    private void Start()
    {
        roomManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<FinRoomManager>();
    }

    public void AddToCombination(string number)
    {
        combination += number;
        if(combination.Length > 9)
        {
            combination = string.Empty;
        }
    }

    private void Update()
    {
        combinationText.text = combination;                
    }

    public void Close()
    {

        foreach(GameObject p in roomManager.players)
        {
            p.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
            p.GetComponent<FirstPersonController>().m_RunSpeed = 8;
            p.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
            p.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
            p.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        combination = string.Empty;
    }

    public void Clear()
    {
        combination = string.Empty;
    }
}
