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
				Destroy(this);
		}
	}
	
	void Examine() {
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("I am touching another object");
    }
}
