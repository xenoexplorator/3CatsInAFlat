using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivePineScript : ObjectiveController
{
    Animator anim;

    protected void Awake()
    {
        manager = GameObject.Find("Manager").GetComponent<IManager>();
        anim = GetComponent<Animator>();
        if(manager.HasPlaced(CollectableType.Pine))
        {
            anim.SetTrigger("GetUp");
            gameObject.tag = "Untagged";
        }
    }

    new protected void Interact(PlayerControllerScript player)
    {
        if (!manager.HasPlaced(CollectableType.Pine))
        {
            anim.SetTrigger("UnSnow");
				manager.PlaceItem(CollectableType.Pine);
            gameObject.tag = "Untagged";
        }
    }
}
