using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowControls()
    {
        //Show Game Controls, probably on a panel or something I guess. How am I supposed to know I'm not your boss, just a comment.
    }
}
