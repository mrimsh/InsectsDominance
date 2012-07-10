using UnityEngine;
using System.Collections;

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
	//public int computerNumRace;
	public GameObject[] prefab;
	public Building targetBuilding;
	public Building initialBuilding;
	
	
	// Use this for initialization
	void Start ()
	{
		numRace = PlayerPrefs.GetInt ("SelectedRace");
		
		
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	
}
