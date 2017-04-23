using UnityEngine;

public class ExaminableObjective : Examinable {
	public CollectableType needed;
	private IManager manager;

	new protected void Start() {
		manager = GameObject.Find("Manager").GetComponent<IManager>();
		base.Start();
	}

	new protected void Update() {
		base.Update();
		var incomplete = transform.Find("Descriptions/Incomplete").GetComponent<Renderer>();
		if (manager.HasPlaced(needed) && incomplete != null && incomplete.enabled) {
			incomplete.enabled = false;
		}
	}

	protected override Renderer FindText() {
		var path = "Descriptions/" + (manager.HasPlaced(needed) ? "Complete" : "Incomplete");
		return transform.Find(path).GetComponent<Renderer>();
	}
}
