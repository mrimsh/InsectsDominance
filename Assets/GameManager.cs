using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	#region Singletone tricks
	private static GameManager gameManager;
	public static GameManager Instance {
		get {
			if (gameManager == null) {
				gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
			}
			return gameManager;
		}
	}
	#endregion
	public int numRace;
	public GameObject[] prefab;
	public Building targetBuilding;
	
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
