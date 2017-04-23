using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobeManager : MonoBehaviour, IManager {

	static private Dictionary<CollectableType, bool> itemsFound;
	static private Dictionary<CollectableType, bool> itemsPlaced;
	static public bool PineRaised;

	// Use this for initialization
	void Start () {
	}

	static public void Initialize() {
		itemsFound = new Dictionary<CollectableType, bool>();
		itemsFound.Add(CollectableType.Axe, false);
		itemsFound.Add(CollectableType.Coal, false);
		itemsFound.Add(CollectableType.Wheel, false);
		itemsFound.Add(CollectableType.Wood, false);

		itemsPlaced = new Dictionary<CollectableType, bool>();
		itemsPlaced.Add(CollectableType.Axe, false);
		itemsPlaced.Add(CollectableType.Coal, false);
		itemsPlaced.Add(CollectableType.Hat, false);
		itemsPlaced.Add(CollectableType.Wheel, false);
	}

	// Update is called once per frame
	void Update () {
		
	}

    public static bool CheckForVictory()
    {
        bool victory = true;
        foreach(KeyValuePair<CollectableType, bool> c in itemsPlaced)
        {
            if(c.Value == false)
            {
                victory = false;
                break;
            }
        }
        return victory;
        
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

	public bool HasFound(CollectableType item) {
		return itemsFound[item];
	}
}
