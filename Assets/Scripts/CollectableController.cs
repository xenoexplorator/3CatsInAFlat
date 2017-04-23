﻿using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class CollectableController : MonoBehaviour {

	public CollectableType type;

	private float examineTimer;
	private Vector3 textOffset;
	private IManager manager;

	public float TextHangTime = 2.0f;
	public float TextFadeTime = 1.0f;
	public Vector3 FadeMovement = Vector3.up / 2.0f;

	// Use this for initialization
	void Start () {
		examineTimer = 0.0f;
		this.textOffset = new Vector3(0.0f, 0.0f, 0.0f);
		manager = GameObject.Find("Manager").GetComponent<IManager>();
	 }

	// Update is called once per frame
	void Update () {
		if (transform.Find("Description") == null) {
			return;
		}
		Renderer text = transform.Find("Description").GetComponent<Renderer>();
		var color = text.material.color;
		if (this.examineTimer < 0.0f) {
			this.examineTimer = 0.0f;
			text.enabled = false;
			color.a = 1.0f;
			text.material.color = color;
			text.transform.Translate(this.textOffset * -1);
			this.textOffset = new Vector3(0.0f, 0.0f, 0.0f);
		} else if (this.examineTimer > 0.0f) {
			this.examineTimer -= Time.deltaTime;
			if (this.examineTimer < TextFadeTime) {
				color.a -= Time.deltaTime / TextFadeTime;
				text.material.color = color;
				var move = FadeMovement * Time.deltaTime;
				this.textOffset += move;
				text.transform.Translate(move);
			}
		}
	}

	 void TakeItem(PlayerControllerScript player) {

		//if (this.type != CollectableType.Wood || player.HasItem(CollectableType.Axe)) {

		    player.AddItem(this.type);

            if (type == CollectableType.Coal)
            {
                Destroy(this);
            }
            else
            {
                Destroy(gameObject);
            }
		//}
	}
	
	void Examine() {
		transform.Find("Description").GetComponent<Renderer>().enabled = true;
		this.examineTimer = TextHangTime + TextFadeTime;
	}

}
