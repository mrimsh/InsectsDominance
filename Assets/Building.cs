using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
	public float insectCount;
	int maxCount;
	public int numRace ;
	public bool race;
	public bool player;
	public float attackersCount;
	public int SPD;
	public int PPL;
	public int DMG;
	public int HP;
	// Use this for initialization
	void Start ()
	{
		insectCount = 10;
		maxCount = 100;
		attackersCount = 0;
		if (player && race) {
			numRace = PlayerPrefs.GetInt ("SelectedRace");
		} else if (race) {
			numRace = Random.Range (0, 4);
			
			while (GameObject.Find ("Building 1").GetComponent<Building> ().numRace == numRace) {
				numRace = Random.Range (0, 4);
				
			}
		}else{
			SPD = 1;
			PPL = 0;
			DMG = 2;
			HP = 2;
		
		}
		if (numRace == 0) {
			SPD = 3;
			PPL = 2;
			DMG = 3;
			HP = 4;
		}
		if (numRace == 1) {
			SPD = 5;
			PPL = 4;
			DMG = 2;
			HP = 2;
		}
		if (numRace == 2) {
			SPD = 2;
			PPL = 1;
			DMG = 4;
			HP = 5;
		}
		if (numRace == 3) {
			SPD = 4;
			PPL = 3;
			DMG = 2;
			HP = 4;
		}
		// Debug.Log ("u : " + GameObject.Find ("Building 1").GetComponent<Building> ().numRace);
		//	Debug.Log ("c : " + GameObject.Find ("Building 2").GetComponent<Building> ().numRace);
	}										
	
	// Update is called once per frame
	void Update ()
	{
		
			
		if (race) {
			if (insectCount < maxCount) {		
				insectCount += Time.deltaTime * PPL;
			}
		}
		if (insectCount > maxCount) {
			insectCount = maxCount;
		}
			
	}

	void OnMouseDrag ()
	{
		GameManager.Instance.initialBuilding = this;
	}

	void OnMouseUp ()
	{	
		if (GameManager.Instance.targetBuilding != this) {
			SendSquad ();
		}
	}

	void OnMouseOver ()
	{
		GameManager.Instance.targetBuilding = this;
	}

	void SendSquad ()
	{
		GameObject createdInsect;
		if (race && insectCount > 0) {
			for (int i=0; i<insectCount/2; i++) {
				createdInsect = Instantiate (GameManager.Instance.prefab [GameManager.Instance.numRace], 
				new Vector3 (transform.position.x, 0, transform.position.z), 
				Quaternion.identity) as GameObject;
				insectCount--;
				attackersCount ++;
			}
		}
		
		
	}
}