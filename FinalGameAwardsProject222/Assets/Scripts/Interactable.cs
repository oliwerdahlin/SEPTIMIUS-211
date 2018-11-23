using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

   // [SerializeField] interactType interactType;

    public virtual void Interact()
    {

    }
}

public enum interactType {numButton , colorSwitch}
