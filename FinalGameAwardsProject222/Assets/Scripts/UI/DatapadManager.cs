using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class DatapadManager : MonoBehaviour {

    [SerializeField] TextMeshProUGUI dataText;
    [SerializeField] GameObject datapadUI;
    public GameObject logContent;

    public static DatapadManager Instance;

	// Use this for initialization
	void Start ()
    {
        Instance = this;
	}

    private void Update()
    {
        //if (FindObjectOfType<FirstPersonController>().m_WalkSpeed == 0 && Input.GetMouseButtonDown(1))
        //{
        //    CloseButtonClick();
        //}
    }

    public void AddNewText(TextAsset asset)
    {
        datapadUI.SetActive(true);
        dataText.text = asset.text;
        //FindObjectOfType<FirstPersonController>().m_WalkSpeed = 0;
    }

    public void CloseButtonClick()
    {
        datapadUI.SetActive(false);
        //FindObjectOfType<FirstPersonController>().m_WalkSpeed = 5;

    }
}
