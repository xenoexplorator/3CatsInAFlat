using UnityEngine;

public class CartController : CollectableController {

	protected override void Remove() {
        gameObject.tag = "Untagged";
        Destroy(this);
	}
}
