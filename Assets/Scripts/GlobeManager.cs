using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeManager : MonoBehaviour, IManager {

	static private Dictionary<CollectableType, bool> itemsFound;
	static private Dictionary<CollectableType, bool> itemsPlaced;

	static public bool AxePicked = false;
	static public bool CoalPicked = false;
	static public bool WheelPicked = false;
	static public bool WoodPicked =false;
	static public bool PineChopped =false;

	static public bool PineRaised =false;
	static public bool CoalPlaced =false;
	static public bool HatPlaced = false;
	static public bool WheelPlaced = false;
	
	// Use this for initialization
	void Start () {
	}

	static public void Initialize() {
		itemsFound.Add(CollectableType.Axe, false);
		itemsFound.Add(CollectableType.Coal, false);
		itemsFound.Add(CollectableType.Wheel, false);
		itemsFound.Add(CollectableType.Wood, false);

		itemsPlaced.Add(CollectableType.Axe, false);
		itemsPlaced.Add(CollectableType.Coal, false);
		itemsPlaced.Add(CollectableType.Hat, false);
		itemsPlaced.Add(CollectableType.Wheel, false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void PlaceItem(CollectableType item) {
		itemsPlaced[item] = true;
	}

	public bool HasPlaced(CollectableType item) {
		return itemsPlaced[item];
	}
}
