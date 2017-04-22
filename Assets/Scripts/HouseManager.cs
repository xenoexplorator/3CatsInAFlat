using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour {

    static public bool hatPicked = false;
    static public bool fireplaceUsed = false;

    void Awake()
    {

    }

    // Use this for initialization
    void Start () {
        TiddyUp();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TiddyUp()
    {
        if (hatPicked)
        {
            Destroy(GameObject.Find("Hat"));
        }
        if (fireplaceUsed)
        {

        }
    }
}
