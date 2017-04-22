using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public float minFov = 10f;
    public float maxFov = 90f;
    public float sensitivity = 2f;
    public Camera cam;

	// Use this for initialization
	void Start () {
        cam.fieldOfView = maxFov;
    }
	
	// Update is called once per frame
	void Update () {
        if (cam.orthographicSize > minFov)
        {
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - sensitivity, minFov,maxFov);
        }
    }
}
