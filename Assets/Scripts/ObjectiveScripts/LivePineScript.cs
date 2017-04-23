using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePineScript : ObjectiveController
{
    Animator anim;

    protected void Awake()
    {
        anim = GetComponent<Animator>();
    }

    new protected void Interact(PlayerControllerScript player)
    {
        if (true) //manager.pinetree == false
        {
            anim.SetTrigger("UnSnow");
            //manager.pinetree = true;
        }
    }
}