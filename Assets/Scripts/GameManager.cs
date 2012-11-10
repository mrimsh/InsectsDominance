using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
#region Singletone tricks
	private static GameManager gameManager;

	public static GameManager Instance {
		get {
			if (gameManager == null) {
				gameManager = GameObject.Find ("GameManager").GetComponent<GameManager> ();
			}
			return gameManager;
		}
	}
#endregion
	public Building targetBuilding;
	public List<Building> buildingsArray;
	public bool drag;
	[HideInInspector]
	public List<Building> buildingsSendingSquad = new List<Building> ();
	public GameObject buildingPrefab;

	void Start ()
	{

	}
	
	/// <summary>
	/// Assembles the level from the MapData
	/// </summary>
	/// <param name='selectedMap'>
	/// Selected map, loaded from XML.
	/// </param>
	public void AssembleLevel (MapData selectedMap)
	{
		Building building;
		for (int i=0; i<selectedMap.buildings.Count; i++) {
			building = (Instantiate (buildingPrefab, 
new Vector3 (selectedMap.buildings [i].position.x, 0, selectedMap.buildings [i].position.y), 
Quaternion.identity) as GameObject).GetComponent<Building> ();
			building.maxCapacity = selectedMap.buildings [i].maxCapacity;
			building.playerOwner = MidSceneObject.Instance.playersInGame[selectedMap.buildings[i].playerID];
			
		}
	}
}