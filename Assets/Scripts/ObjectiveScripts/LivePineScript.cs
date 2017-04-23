using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePineScript : ObjectiveController
{
    Animator anim;

    protected void Awake()
    {
        anim = GetComponent<Animator>();
        if(GlobeManager.PineRaised)
        {
            anim.SetTrigger("GetUp");
            gameObject.tag = "Untagged";
        }
    }

    new protected void Interact(PlayerControllerScript player)
    {
        if (GlobeManager.PineRaised == false)
        {
            anim.SetTrigger("UnSnow");
            GlobeManager.PineRaised = true;
            gameObject.tag = "Untagged";
        }
    }
}