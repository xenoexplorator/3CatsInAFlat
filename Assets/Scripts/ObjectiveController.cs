﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveController : MonoBehaviour {

	public ObjectiveType type;
	public CollectableType needed;
	public GameObject collectable;
	public IManager manager;

	// Use this for initialization
	protected void Start () {
		if (collectable != null) {
			collectable.SetActive(manager.HasPlaced(needed));
		}
	}
	
	// Update is called once per frame
	protected void Update () {
	}

	protected void PlaceItem(PlayerControllerScript player, CollectableType item, GameObject coll) {
		player.RemoveItem(item);
		if (coll != null) {
			coll.SetActive(true);
		}
		manager.PlaceItem(item);
	}

	protected void Interact(PlayerControllerScript player) {
		if (player.HasItem(needed)) {
			PlaceItem(player, needed, collectable);
		}
	}

	protected void Examine() {
	}

}
