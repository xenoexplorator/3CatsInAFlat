using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeManager : MonoBehaviour {

	static public bool AxePicked = false;
	static public bool CoalPicked = false;
	static public bool WheelPicked = false;
	static public bool WoodPicked =false;
	static public bool PineChopped =false;

	static public bool PineRaised =false;
	static public bool CoalPlaced =false;
	static public bool HatPlaced = false;
	static public bool WheelPlaced = false;
	
	// Use this for initialization
	void Start () {
		Debug.Log("No hats for this snowman!");
		TidyUp();
	}

	void TidyUp() {
		if (AxePicked) {
			Destroy(GameObject.Find("Axe"));
		}
		if (!HatPlaced) {
			Destroy(GameObject.Find("Hat"));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
