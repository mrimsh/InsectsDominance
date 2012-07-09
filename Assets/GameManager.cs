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
	public int movementSpeed;
	public int reproductionSpeed;
	// Use this for initialization
	void Start ()
	{
		numRace = PlayerPrefs.GetInt ("SelectedRace");
		//Debug.Log(numRace);
		if(numRace == 0){
			reproductionSpeed = 2;
			movementSpeed = 2;
		}
		if(numRace == 1){
			reproductionSpeed = 3;
			movementSpeed = 4;
		}
		if(numRace == 2){
			reproductionSpeed = 1;
			movementSpeed = 2;
		}
		if(numRace == 3){
			reproductionSpeed = 4;
			movementSpeed = 3;
		}
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	
}
