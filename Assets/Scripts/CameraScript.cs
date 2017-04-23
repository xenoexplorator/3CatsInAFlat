using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float minFov = 10f;
    public float maxFov = 90f;
    public float sensitivity = 2f;
    public Camera cam;
    static public int state = 1; //0 zoom on player, 1 zoom-out

	// Use this for initialization
	void Start () {
        cam.fieldOfView = maxFov;
    }
	
	// Update is called once per frame
	void Update () {
        if (state == 0)
        {
            if (cam.orthographicSize > minFov)
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - (sensitivity*2), minFov, maxFov);
            }
        }
        else if(state == 1)
        {
            if (cam.orthographicSize < maxFov)
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + sensitivity, minFov, maxFov);
            }
        }
    }
}
