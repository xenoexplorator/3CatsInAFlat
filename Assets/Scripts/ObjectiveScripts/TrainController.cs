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

    private float maxspeed = 8;
    private float currentspeed = 0;
    private float acceleration = 0.01f;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        anim.ResetTrigger("Roll");
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
            int h = 1;
            if (positionSide)
                h = -1;
            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x + (currentspeed * h), 
                gameObject.transform.position.y, 
                gameObject.transform.position.z);
            currentspeed += acceleration;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Train Stopped trigger collision with object: " + collision.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Train entered trigger collision with object: " + collision.gameObject.name);
            if (collision.gameObject.tag == "Station")
            {
            gameObject.transform.position = collision.gameObject.transform.position;
            gameObject.transform.rotation = collision.gameObject.transform.rotation;
            gameObject.transform.localScale = collision.gameObject.transform.localScale;
            positionSide = !positionSide;
            IsInStation = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Train entered collision with object: " + collision.gameObject.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Train stopped collision with object: " + collision.gameObject.name);
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
            anim.SetTrigger("Roll");
        }
    }

    private void ChangeStation()
    {
        IsInStation = false;
        //if(positionSide == false)
        //{
        //    gameObject.transform.position = rightStationOrigin.transform.position;
        //    gameObject.transform.rotation = rightStationOrigin.transform.rotation;
        //    gameObject.transform.localScale = rightStationOrigin.transform.localScale;
        //    positionSide = true;
        //}
        //else
        //{
        //    gameObject.transform.position = leftStationOrigin.transform.position;
        //    gameObject.transform.rotation = leftStationOrigin.transform.rotation;
        //    gameObject.transform.localScale = leftStationOrigin.transform.localScale;
        //    positionSide = false;
        //}
    }
}
