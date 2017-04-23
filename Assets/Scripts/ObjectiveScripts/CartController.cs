using UnityEngine;

public class CartController : CollectableController {

	new protected void Start () {
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
        gameObject.tag = "Untagged";
        Destroy(this);
	}
}
