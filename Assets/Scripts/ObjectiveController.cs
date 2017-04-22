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
	protected void Update () {
		
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
		for (var i = needed.Count - 1; i >= 0; i--) {
			var item = needed[i];
			if (player.HasItem(item)) {
				this.PlaceItem(player, item);
				break;
			}
		}
	}

	protected void Examine() {
		if (player.HasItem(needed)) {
			PlaceItem(player, needed);
		}
	}

	protected void Examine() {
	}

}
