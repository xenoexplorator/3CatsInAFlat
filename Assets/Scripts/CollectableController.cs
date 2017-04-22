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

	void TakeItem(PlayerControllerScript player) {
		if (this.type != CollectableType.Wood || player.HasItem(CollectableType.Axe)) {
				player.AddItem(this.type);
				Destroy(this);
		}
		// TODO update sprite / object state
	}
	
	void Examine() {
		// TODO display examination text object
	}
}
