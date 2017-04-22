using UnityEngine;

public class SnowmanController : ObjectiveController {

	new protected void Interact(PlayerControllerScript player) {
		if (player.HasItem(CollectableType.Coal)) {
			PlaceItem(player, CollectableType.Coal);
		} else if (player.HasItem(CollectableType.Hat)) {
			PlaceItem(player, CollectableType.Hat);
		}
	}
}
