using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType { Axe, Coal, Hat, Wheel, Wood };

public class CollectableController : MonoBehaviour {

	public CollectableType type;

	// Use this for initialization
	void Start () {
        Debug.Log("Trigger: " + GetComponent<Collider2D>().isTrigger);
    }
	
	// Update is called once per frame
	void Update () {
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
		// TODO display examination text object
		var text = transform.Find("Description");
		text.GetComponent<Renderer>().enabled = !text.GetComponent<Renderer>().enabled;
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
