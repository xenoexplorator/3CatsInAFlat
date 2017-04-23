using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraScript : MonoBehaviour {
    
    public float minFov;
    public float maxFov;
    public float sensitivity;
    public float zoomOutSpeed;
    public Camera cam;
    static public int state = 0; //0 zoom on player, 1 zoom-out, 2 zoom out end game
    [HideInInspector]
    static public bool idle = false;

	// Use this for initialization
	void Start () {
        cam.fieldOfView = maxFov;
    }
	
	// Update is called once per frame
	void Update () {
        //Zoom in
        if (state == 0)
        {
            if (cam.orthographicSize > minFov)
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize - sensitivity, minFov, maxFov);
                if (cam.orthographicSize == minFov)
                    idle = true;
            }
        }
        //Zoom out
        else if(state == 1)
        {
            if (cam.orthographicSize < maxFov)
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + zoomOutSpeed, minFov, maxFov);
            }
        }
        //End game
        else if (state ==2)
        {
            if (cam.orthographicSize < maxFov)
            {
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize + (zoomOutSpeed*3), minFov, maxFov);
                if (cam.orthographicSize == maxFov)
                    idle = true;
            }
            if (idle)
            {
                //FadeToBlack();
                if (true)//if fade to black completed
                {
                    SceneManager.LoadScene("End");
                }
            }
            
        }
    }

    static public void FadeToBlack()
    {
        iTween.CameraFadeAdd();
        iTween.CameraFadeTo(1.0f, 5.0f);
    }
}
