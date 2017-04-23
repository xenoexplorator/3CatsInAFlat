using UnityEngine;

public class CartController : CollectableController {

	new protected void Start () {
		examineTimer = 0.0f;
		textOffset = new Vector3(0.0f, 0.0f, 0.0f);
		manager = GameObject.Find("Manager").GetComponent<IManager>();
		if (manager.HasFound(type)) {
			Remove();
		}
	}

	new protected void TakeItem(PlayerControllerScript player) {
		player.AddItem(type);
		manager.FindItem(type);
		Remove();
	}
	
	new protected void Remove() {
		Destroy(this);
	}
}
