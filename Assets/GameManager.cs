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
	public int[] selectedRaces;
	public bool drag;
	[HideInInspector]
	public List<Building> buildingsSendingSquad = new List<Building> ();
		
	// Use this for initialization
	void Awake ()
	{

	}

	void Start ()
	{
		selectedRaces [0] = PlayerPrefs.GetInt ("SelectedRace");
		do {
			selectedRaces [1] = Random.Range (0, 4);
		} while (selectedRaces[1] == selectedRaces[0]);
		 
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}