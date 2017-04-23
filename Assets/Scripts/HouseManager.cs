using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour, IManager {

	static private Dictionary<CollectableType, bool> itemsFound;
	static private Dictionary<CollectableType, bool> itemsPlaced;

    static public bool hatPicked = false;
    static public bool fireplaceUsed = false;

    void Awake()
    {

    }

    // Use this for initialization
    void Start () {
    }

	 static public void Initialize() {
	 }
	
	// Update is called once per frame
	void Update () {
		
	}

    void TiddyUp()
    {
        if (hatPicked)
        {
            Destroy(GameObject.Find("Hat"));
        }
        if (fireplaceUsed)
        {

        }
    }

	public void PlaceItem(CollectableType item) {
		itemsPlaced[item] = true;
	}

	public bool HasPlaced(CollectableType item) {
		return itemsPlaced[item];
	}
}
