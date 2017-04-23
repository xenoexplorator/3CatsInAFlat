using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class CollectableController : MonoBehaviour {

	public CollectableType type;

	protected float examineTimer;
	protected Vector3 textOffset;
	protected IManager manager;

	public float TextHangTime = 2.0f;
	public float TextFadeTime = 1.0f;
	public Vector3 FadeMovement = Vector3.up / 2.0f;

	// Use this for initialization
	protected void Start () {
		examineTimer = 0.0f;
		textOffset = new Vector3(0.0f, 0.0f, 0.0f);
		manager = GameObject.Find("Manager").GetComponent<IManager>();
		if (manager.HasFound(type)) {
			Remove();
		}
	 }

	// Update is called once per frame
	void Update () {
		if (transform.Find("Description") == null) {
			return;
		}
		Renderer text = transform.Find("Description").GetComponent<Renderer>();
		var color = text.material.color;
		if (examineTimer < 0.0f) {
			examineTimer = 0.0f;
			text.enabled = false;
			color.a = 1.0f;
			text.material.color = color;
			text.transform.Translate(textOffset * -1);
			textOffset = new Vector3(0.0f, 0.0f, 0.0f);
		} else if (examineTimer > 0.0f) {
			examineTimer -= Time.deltaTime;
			if (examineTimer < TextFadeTime) {
				color.a -= Time.deltaTime / TextFadeTime;
				text.material.color = color;
				var move = FadeMovement * Time.deltaTime;
				textOffset += move;
				text.transform.Translate(move);
			}
		}
	}

	 protected void TakeItem(PlayerControllerScript player) {
		 player.AddItem(type);
		 manager.FindItem(type);
		 Remove();
	}
	
	void Examine() {
		transform.Find("Description").GetComponent<Renderer>().enabled = true;
		examineTimer = TextHangTime + TextFadeTime;
	}

	protected void Remove() {
		Destroy(gameObject);
	}

}
