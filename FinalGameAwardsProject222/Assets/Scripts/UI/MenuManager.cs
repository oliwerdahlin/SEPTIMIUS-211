using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuManager : MonoBehaviour {


    public static MenuManager instance;
    public GameObject pausMenu;
    public GameObject pausMenuImage;
    public GameObject logJournal;

    public GameObject lobbyCanvas;

    public bool menusCanBeEnabled = true;

    FinRoomManager roomManager;

   // float menuActiveCooldown = 0.1f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        roomManager = FinRoomManager.instance;
    }

    public bool MenusActive()
    {
        foreach(Transform g in transform)
        {
            if(g != this.transform && g.gameObject.activeInHierarchy)
            {
                return true;
            }          
        }
        return false;
    }

    private void Update()
    {
        if(pausMenuImage.activeInHierarchy)
        {
            foreach (GameObject p in roomManager.players)
            {
                p.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
                p.GetComponent<FirstPersonController>().m_RunSpeed = 0;
                p.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                p.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                p.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Escape) && !lobbyCanvas.activeInHierarchy)
        {
            Debug.Log(MenusActive());
            foreach(Transform g in transform)
            {
                if(g != this.gameObject && g != pausMenu.transform)
                {
                    menusCanBeEnabled = false;
                    g.gameObject.SetActive(false);
                    menusCanBeEnabled = true;
                    //StartCoroutine(MenuCooldown());
                }
            }
            
            foreach (GameObject p in roomManager.players)
            {
                p.GetComponent<FirstPersonController>().m_WalkSpeed = 5;
                p.GetComponent<FirstPersonController>().m_RunSpeed = 8;
                p.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 2;
                p.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 2;
                p.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = true;

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            menusCanBeEnabled = true;

        }

        if(Input.GetKeyDown(KeyCode.J))
        {
            logJournal.SetActive(true);
            foreach (GameObject p in roomManager.players)
            {
                p.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
                p.GetComponent<FirstPersonController>().m_RunSpeed = 0;
                p.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                p.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                p.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    //IEnumerator MenuCooldown()
    //{
    //    menusCanBeEnabled = false;
    //    yield return new WaitForSeconds(menuActiveCooldown);
    //    menusCanBeEnabled = true;
    //}
}
