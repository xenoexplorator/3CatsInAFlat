using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChimneyScript : ObjectiveController {

    public GameObject smoke;

	// Use this for initialization
	new void Start () {
		if(HouseManager.StaticHasPlaced(CollectableType.Wood))
        {
            smoke.SetActive(true);
        }
	}
	
}
