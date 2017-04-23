using UnityEngine;

public class Examinable : MonoBehaviour {
	private float examineTimer;
	private Vector3 textOffset;

	public float TextHangTime = 2.0f;
	public float TextFadeTime = 1.0f;
	public Vector3 FadeMovement = Vector3.up / 2.0f;

	protected void Start() {
		examineTimer = 0.0f;
		textOffset = new Vector3(0.0f, 0.0f, 0.0f);
	}

	protected void Update() {
		var text = FindText();
		if (text == null) {
			return;
		}
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

	protected virtual Renderer FindText() {
		return transform.Find("Descriptions/Item").GetComponent<Renderer>();
	}

	void Examine() {
		var text = FindText();
		if (text == null) {
			return;
		}
		text.enabled = true;
		examineTimer = TextHangTime + TextFadeTime;
	}
}
