public interface IManager {
	void PlaceItem(CollectableType item);
	void FindItem(CollectableType item);
	bool HasPlaced(CollectableType item);
	bool HasFound(CollectableType item);
}
