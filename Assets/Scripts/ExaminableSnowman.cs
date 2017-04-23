using UnityEngine;

public class ExaminableSnowman : Examinable {
	private IManager manager;

	new protected void Start() {
		manager = GameObject.Find("Manager").GetComponent<IManager>();
		base.Start();
	}

	new protected void Update() {
		base.Update();
		var hat = manager.HasPlaced(CollectableType.Hat);
		var coal = manager.HasPlaced(CollectableType.Coal);
		var incomplete = transform.Find("Descriptions/Incomplete").GetComponent<Renderer>();
		if ((hat || coal) && incomplete != null && incomplete.enabled) {
			incomplete.enabled = false;
		}
		var partial = transform.Find("Descriptions/Partial").GetComponent<Renderer>();
		if (hat && coal && partial != null && partial.enabled) {
			partial.enabled = false;
		}
	}

	protected override Renderer FindText() {
		var hat = manager.HasPlaced(CollectableType.Hat);
		var coal = manager.HasPlaced(CollectableType.Coal);
		var partial = hat || coal;
		var complete = hat && coal;
		var path = "Descriptions/" + (complete ? "Complete" : (partial ? "Partial" : "Incomplete"));
		return transform.Find(path).GetComponent<Renderer>();
	}
}
