using UnityEngine;

public class NumberButton : Interactable {

    public string CharacterToAdd;

    [SerializeField] PhotonView photonView;
    Animator anim;

    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    public override void Interact()
    {
        base.Interact();
        if(anim != null)
        {
            photonView.RPC("Setanim", PhotonTargets.All);
        }
    }

    [PunRPC]
    void Setanim()
    {
        anim.SetTrigger("Press");
    }

}
