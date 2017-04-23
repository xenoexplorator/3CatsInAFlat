using UnityEngine;

public class ExaminableObjective : Examinable {
	public CollectableType needed;
	private IManager manager;

	new protected void Start() {
		manager = GameObject.Find("Manager").GetComponent<IManager>();
		base.Start();
	}

	protected override Renderer FindText() {
		var path = "Descriptions/" + (manager.HasPlaced(needed) ? "Complete" : "Incomplete");
		return transform.Find(path).GetComponent<Renderer>();
	}
}
