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
	public int numRace;
	public Race[] races;
	public Building targetBuilding;
	public List<Building> buildingsArray;
	public bool drag;
	[HideInInspector]
	public List<Building> buildingsSendingSquad = new List<Building> ();

	void Start ()
	{

	}

}