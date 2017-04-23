using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour, IManager {

	static private Dictionary<CollectableType, bool> itemsFound;
	static private Dictionary<CollectableType, bool> itemsPlaced;

    // Use this for initialization
    void Start () {
    }

	 static public void Initialize() {
		itemsFound = new Dictionary<CollectableType, bool>();
		itemsFound.Add(CollectableType.Hat, false);

		itemsPlaced = new Dictionary<CollectableType, bool>();
		itemsPlaced.Add(CollectableType.Wood, false);
	 }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaceItem(CollectableType item) {
		itemsPlaced[item] = true;
	}

	public void FindItem(CollectableType item) {
		itemsFound[item] = true;
	}

	public bool HasPlaced(CollectableType item) {
		return itemsPlaced[item];
	}

    public static bool StaticHasPlaced(CollectableType item)
    {
        return itemsPlaced[item];
    }

    public bool HasFound(CollectableType item) {
		return itemsFound[item];
	}
}
