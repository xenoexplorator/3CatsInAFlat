using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour {

	public ObjectiveType type;
	public CollectableType needed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void PlaceItem(PlayerControllerScript player, CollectableType item) {
		player.RemoveItem(item);
		switch(this.type) {
			case ObjectiveType.Snowman:
				if (item == CollectableType.Hat) {
					GlobeManager.HatPlaced = true;
				}
				break;
		}
	}

	protected void Interact(PlayerControllerScript player) {
		if (player.HasItem(needed)) {
			PlaceItem(player, needed);
		}
	}

	void Examine() {
		// TODO display examination text object
	}

}
