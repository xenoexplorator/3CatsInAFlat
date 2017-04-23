using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : ObjectiveController {

    static bool positionSide = false; //False = left, true = right
    public SpriteRenderer missingWheel;
    public Animator anim;
    private bool IsInStation = true;
    public GameObject leftStationOrigin;
    public GameObject rightStationOrigin;

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
        if(IsInStation == false)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 4, gameObject.transform.position.y, gameObject.transform.position.z);
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
        if(positionSide == false)
        {
            gameObject.transform.position = rightStationOrigin.transform.position;
            gameObject.transform.rotation = rightStationOrigin.transform.rotation;
            gameObject.transform.localScale = rightStationOrigin.transform.localScale;
            positionSide = true;
        }
        else
        {
            gameObject.transform.position = leftStationOrigin.transform.position;
            gameObject.transform.rotation = leftStationOrigin.transform.rotation;
            gameObject.transform.localScale = leftStationOrigin.transform.localScale;
            positionSide = false;
        }
    }
}
