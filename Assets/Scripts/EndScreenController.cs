using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreenController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        CameraScript.FadeFromBlack(3);
        StartCoroutine("Endgame");
	}

    IEnumerator Endgame()
    {
        yield return new WaitForSeconds(10);
        CameraScript.FadeToBlack(3);
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
}
