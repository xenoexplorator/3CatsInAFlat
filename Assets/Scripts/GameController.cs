using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public PlayerControllerScript player;
    static public GameController instance;
    public Sprite black;

    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance
            Destroy(gameObject);
        }
		  // Initialize global game state
		  GlobeManager.Initialize();
		  HouseManager.Initialize();
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        SceneManager.LoadScene("Globe");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
