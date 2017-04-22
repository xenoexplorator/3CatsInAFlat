using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectiveType { DeadPine, Fireplace, LivePine, Snowman, SnowPile, Train };

public class ObjectiveController : MonoBehaviour {

	public ObjectiveType type;
	public List<CollectableType> needed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void PlaceItem(PlayerControllerScript player, CollectableType item) {
		player.RemoveItem(item);
		this.needed.Remove(item);
		switch(this.type) {
			case ObjectiveType.Snowman:
				if (item == CollectableType.Hat) {
					GlobeManager.HatPlaced = true;
				}
				break;
		}
	}

	void Interact(PlayerControllerScript player) {
		for (var i = needed.Count - 1; i >= 0; i--) {
			var item = needed[i];
			if (player.HasItem(item)) {
				this.PlaceItem(player, item);
				break;
			}
		}
		// TODO update sprite / object state
	}

	void Examine() {
		// TODO display examination text object
	}

}
