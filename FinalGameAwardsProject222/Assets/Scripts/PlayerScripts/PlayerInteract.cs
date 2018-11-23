using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerInteract : MonoBehaviour {

    [SerializeField] float range = 3;
    [SerializeField] LayerMask mask;
    [SerializeField] LayerMask mirrorMask;
    [SerializeField] LayerMask laserEndMask;
    [SerializeField] AudioClip buttonClickClip;
    AudioSource adSource;

    PhotonView photonView;

    public Transform grabbedobjectTransform;

    public float objectPickupCooldown = 0.5f;

    public bool carryingObject = false;
    public bool canDropObject = true;

    public PickupableObject carriedObject;

    [SerializeField] Sprite nonInteractImage;
    [SerializeField] Sprite interactImage;

    private Camera cam;

    [SerializeField] FinRoomManager roomManager;

	// Use this for initialization
	void Start ()
    {
        cam = GetComponent<Camera>();
        adSource = GetComponent<AudioSource>();
        photonView = GetComponentInParent<PhotonView>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        RaycastHit mirrorHit;
		if(Input.GetMouseButtonDown(0) && !carryingObject)
        {
            Interact();
        }
        if(Input.GetMouseButtonDown(0) && carryingObject && canDropObject)
        {
            carriedObject.Drop1();
            photonView.RPC("RemoveCarriedObject", PhotonTargets.All);
            //RemoveCarriedObject();
        }
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, range, mask) || Physics.Raycast(cam.transform.position, cam.transform.forward, range, mirrorMask))
        {
            GetComponentInParent<PlayerNetwork>().cursor.sprite = interactImage;
        }
        else
        {
            GetComponentInParent<PlayerNetwork>().cursor.sprite = nonInteractImage;
        }
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out mirrorHit, range, mirrorMask) && Input.GetMouseButtonDown(0))
        {
            if(mirrorHit.collider.GetComponent<Mirror>() != null)
            {
                mirrorHit.collider.GetComponent<Mirror>().StartToggleRotation();
            }
        }
    }

    void Interact()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, range, mask))
        {
            if(GetComponentInChildren<MultiTool>().mode == ToolMode.Flashlight)
            {
                return;
            }

            GetComponentInChildren<MultiTool>().flashlight.SetActive(false);

            Debug.Log("Interacting with " + _hit.collider.name);

            if (_hit.transform.GetComponent<PickupableObject>() != null && GetComponentInChildren<MultiTool>().mode == ToolMode.Lift)
            {
                carriedObject = _hit.transform.GetComponent<PickupableObject>();
                Debug.Log(carriedObject);
                carriedObject.Pickup();
                _hit.transform.parent = this.transform;

                //_hit.transform.position = new Vector3(0, 0, 2);
                carryingObject = true;
                StartCoroutine(ObjectpickupTimer());
            }


            if (_hit.transform.GetComponent<Interactable>() != null && GetComponentInChildren<MultiTool>().mode == ToolMode.Activation)
            {
                _hit.transform.GetComponent<Interactable>().Interact();
            }

            if (_hit.transform.gameObject.GetComponent<NumberButton>() != null && GetComponentInChildren<MultiTool>().mode == ToolMode.Activation)
            {
                GetComponentInParent<NumberRoomControllerPlayer>().AddToCurrentCombo(_hit.transform.gameObject.GetComponent<NumberButton>().CharacterToAdd);
                adSource.PlayOneShot(buttonClickClip);
            }
            if (_hit.transform.GetComponent<ColorLever>() != null && GetComponentInChildren<MultiTool>().mode == ToolMode.Activation)
            {
                GetComponentInParent<AirLockRoomPlayer>().AddToCurrent(_hit.transform.GetComponent<ColorLever>().StringToAdd);
            }

            if (_hit.transform.GetComponent<LaserSpawnButton>() != null && GetComponentInChildren<MultiTool>().mode == ToolMode.Activation)
            {
                _hit.transform.GetComponent<LaserSpawnButton>().Interact();
            }

            if (_hit.transform.CompareTag("Keypad") && GetComponentInChildren<MultiTool>().mode == ToolMode.Activation)
            {
                _hit.transform.GetComponent<KeypadObjective>().SetCanvas(true);
                GetComponentInParent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                GetComponentInParent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
                GetComponentInParent<FirstPersonController>().m_WalkSpeed = 0;
                GetComponentInParent<FirstPersonController>().m_RunSpeed = 0;
                GetComponentInParent<FirstPersonController>().m_MouseLook.lockCursor = false;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

            if (_hit.transform.GetComponent<ForceFieldButton>() != null && GetComponentInChildren<MultiTool>().mode == ToolMode.Activation)
            {
                _hit.transform.GetComponent<ForceFieldButton>().Complete();
            }

        }
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, range, laserEndMask) && GetComponentInChildren<MultiTool>().mode == ToolMode.Activation)
        {
            GetComponentInChildren<MultiTool>().ActivateLaserEnd(_hit.transform.GetComponent<LaserEndPoint>());
        }
    }
        

    IEnumerator ObjectpickupTimer()
    {
        canDropObject = false;
        yield return new WaitForSeconds(objectPickupCooldown);
        canDropObject = true;
    }

    [PunRPC]
    void RemoveCarriedObject()
    {
        carriedObject = null;
        carryingObject = false;
    }
}
