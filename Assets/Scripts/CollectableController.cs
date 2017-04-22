using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType { Axe, Coal, Hat, Wheel, Wood };

public class CollectableController : MonoBehaviour {

	public CollectableType type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Collect(PlayerControllerScript player) {
		//player.addItem(self.Name);
	}

	void Use() {
	}

	void Examine() {
	}
}
