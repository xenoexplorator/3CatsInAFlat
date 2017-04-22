using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseScript : MonoBehaviour {

    public BoxCollider2D[] platforms;

	// Use this for initialization
	void Start () {
        EnableCollision(true);
	}

    private void EnableCollision(bool state)
    {
        foreach (BoxCollider2D b in platforms)
        {
            b.enabled = state;
        }
    }
	
	// Update is called once per frame
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnableCollision(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            EnableCollision(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnableCollision(true);
        }
    }
}
