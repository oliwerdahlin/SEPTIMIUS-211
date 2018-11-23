using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiTool : MonoBehaviour {

    PlayerInteract playerinteract;
    LineRenderer lineRenderer;

    LaserEndPoint endPoint;


    public Color activationColor;
    public Color liftColor;
    public Color flashlightColor;

    public GameObject modeIndicator;

    public GameObject flashlight;

    public Transform cursorPosition;

    public LaserEndPoint activatedEndPoint;

    public ToolMode mode;

	void Start ()
    {
        mode = ToolMode.Activation;

        modeIndicator.GetComponent<MeshRenderer>().material.color = activationColor;

        playerinteract = GetComponentInParent<PlayerInteract>();
        lineRenderer = GetComponentInChildren<LineRenderer>();
        flashlight = GetComponentInChildren<Light>().gameObject;
        lineRenderer.enabled = false;
        flashlight.SetActive(false);
	}
	
	void Update ()
    {
		if(playerinteract.carriedObject != null)
        {
            lineRenderer.enabled = true;
        }
        if (playerinteract.carriedObject == null)
        {
            lineRenderer.enabled = false;
        }

        if(mode == ToolMode.Flashlight && Input.GetMouseButtonDown(0))
        {
            if(!flashlight.activeInHierarchy)
            {
                flashlight.SetActive(true);
                return;
            }
            if (flashlight.activeInHierarchy)
            {
                flashlight.SetActive(false);
                return;
            }
        }
        #region Modetoggle
        if (mode == ToolMode.Activation && Input.GetMouseButtonDown(1))
        {
            mode = ToolMode.Flashlight;
            modeIndicator.GetComponent<MeshRenderer>().material.color = flashlightColor;

            return;
        }
        if (mode == ToolMode.Flashlight && Input.GetMouseButtonDown(1))
        {
            mode = ToolMode.Lift;
            modeIndicator.GetComponent<MeshRenderer>().material.color = liftColor;

            flashlight.SetActive(false);
            return;

        }
        if (mode == ToolMode.Lift && Input.GetMouseButtonDown(1))
        {
            mode = ToolMode.Activation;
            modeIndicator.GetComponent<MeshRenderer>().material.color = activationColor;

            return;

        }
        #endregion
    }

    public void ActivateLaserEnd(LaserEndPoint _endpoint)
    {
        if(endPoint != null)
        {
            endPoint.UnComplete();
            endPoint = null;
        }

        endPoint = _endpoint;
        endPoint.Complete();
    }
}

public enum ToolMode { Lift, Activation, Flashlight}
