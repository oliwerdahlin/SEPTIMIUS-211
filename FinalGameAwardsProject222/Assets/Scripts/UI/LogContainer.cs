using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogContainer : MonoBehaviour {

    public DataPadContent log;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI contentText;


	void Start ()
    {
        titleText.text = log.Title;
        contentText = GameObject.FindGameObjectWithTag("JournalContent").GetComponent<TextMeshProUGUI>();
	}

    public void Click()
    {
        if(contentText.text != log.bodyText.text)
        {
            contentText.text = log.bodyText.text;
            return;
        }
        if(contentText.text == log.bodyText.text)
        {
            contentText.text = null;
        }
    }
}
