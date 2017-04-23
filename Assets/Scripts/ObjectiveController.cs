using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour {

	public ObjectiveType type;
	public CollectableType needed;
	public GameObject collectable;

	// Use this for initialization
	void Start () {
		collectable?.SetActive(false);
	}
	
	// Update is called once per frame
	protected void Update () {
	}

	protected void PlaceItem(PlayerControllerScript player, CollectableType item) {
		player.RemoveItem(item);
		collectable?.SetActive(true);
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

	protected void Examine() {
	}

}
