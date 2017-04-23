using UnityEngine;

public class SnowmanController : ObjectiveController {

	public CollectableType needed2;
	public GameObject collectable2;

	new protected void Start() {
		base.Start();
		if (collectable2 != null) {
			collectable2.SetActive(manager.HasPlaced(needed2));
		}
	}

	new protected void Interact(PlayerControllerScript player) {
		if (player.HasItem(needed2)) {
			PlaceItem(player, needed2, collectable2);
		} else {
			base.Interact(player);
		}
	}
}
