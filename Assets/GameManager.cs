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
	//public int computerNumRace;
	public Race [] races;
	public Building targetBuilding;
	public Building initialBuilding;
	public List<Buiding> buildingsArray;
	// Use this for initialization
	void Start ()
	{
		
		playerNumRace = PlayerPrefs.GetInt ("SelectedRace");	
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	
}
