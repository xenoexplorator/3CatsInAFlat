using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class CollectableController : MonoBehaviour {

	public CollectableType type;

	protected IManager manager;

	// Use this for initialization
	protected void Start () {
		manager = GameObject.Find("Manager").GetComponent<IManager>();
		if (manager.HasFound(type)) {
			Remove();
		}
	 }

	// Update is called once per frame
	protected void Update () {
	}

	 protected void TakeItem(PlayerControllerScript player) {
		 player.AddItem(type);
		 manager.FindItem(type);
		 Remove();
	}
	
	protected virtual void Remove() {
		Destroy(gameObject);
	}

}
