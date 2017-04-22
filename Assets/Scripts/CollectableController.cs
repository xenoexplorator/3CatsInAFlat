using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public enum CollectableType { Axe, Coal, Hat, Wheel, Wood };

public class CollectableController : MonoBehaviour {

	public CollectableType type;

	private float examineTimer;

	// Use this for initialization
	void Start () {
		this.examineTimer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
		if (this.examineTimer < 0) {
			this.examineTimer = 0.0f;
			transform.Find("Description").GetComponent<Renderer>().enabled = false;
		} else if (this.examineTimer > 0) {
			this.examineTimer -= Time.deltaTime;
		}
	}

    void TakeItem(PlayerControllerScript player) {
		if (this.type != CollectableType.Wood || player.HasItem(CollectableType.Axe)) {
				player.AddItem(this.type);
				Destroy(gameObject);
            WarnManagers();
		}
		// TODO update sprite / object state
	}
	
	void Examine() {
		transform.Find("Description").GetComponent<Renderer>().enabled = true;
		this.examineTimer = 3;
	}

    void WarnManagers()
    {
        switch (type){
            case CollectableType.Axe:
                
                break;
            case CollectableType.Coal:
                break;
            case CollectableType.Hat:
                HouseManager.hatPicked = true;
                break;
            case CollectableType.Wheel:
                break;
            case CollectableType.Wood:
                break;
        }
    }
}
