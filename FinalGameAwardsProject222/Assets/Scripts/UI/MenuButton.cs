using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour {

    public GameObject elementToEnable;

    public void Click()
    {
        elementToEnable.SetActive(true);
    }

}
