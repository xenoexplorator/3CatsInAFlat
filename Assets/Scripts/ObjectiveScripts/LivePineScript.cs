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
        }
    }

    new protected void Interact(PlayerControllerScript player)
    {
        if (GlobeManager.PineRaised == false) //manager.pinetree == false
        {
            anim.SetTrigger("UnSnow");
            GlobeManager.PineRaised = true;
        }
    }
}