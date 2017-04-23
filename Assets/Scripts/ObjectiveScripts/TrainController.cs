using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : ObjectiveController {

    static bool positionSide = false; //False = left, true = right
    public SpriteRenderer missingWheel;
    public Animator anim;
    private bool IsInStation = true;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    new private void Update()
    {
        if(GlobeManager.WheelPlaced == true)
        {
            if(missingWheel.enabled == false)
            {
                missingWheel.enabled = true;
            }
        }
    }

    new protected void Interact(PlayerControllerScript player)
    {
        if(GlobeManager.WheelPlaced && IsInStation)
        {
            ChangeStation();
        }
        else
        {
            base.Interact(player);
        }
    }

    private void ChangeStation()
    {

    }
}
