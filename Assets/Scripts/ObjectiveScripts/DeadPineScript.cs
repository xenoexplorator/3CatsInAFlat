using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPineScript : ObjectiveController
{
    bool falling = false;
    float rotation = 0;
    public GameObject rotationPoint;
    new protected void Update()
    {
        if(falling)
        {
            gameObject.transform.RotateAround(rotationPoint.transform.position, Vector3.forward,rotation);
            //gameObject.transform.Rotate(0, 0, rotation);
            rotation += 0.025f;
            if(rotation >= 2.2)
            {
                Destroy(gameObject);
                //Create pile of wood
            }
        }
    }

    new protected void Interact(PlayerControllerScript player)
    {
        base.Interact(player);
        if(needed.Count == 0)
        {
            falling = true;
        }
    }

}
