using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour {

    public string name;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlaceItem(PlayerControllerScript player, CollectableType item) {
		player.RemoveItem(item);
	}

}
