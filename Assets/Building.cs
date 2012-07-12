using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
	public float insectCount;
	public int maxCount;
	public int playerNumRace ;
	public int computerNumRace ;
	public bool race;
	public bool player;
	public float attackersCount;
	public int SPD;
	public float PPL;
	public int DMG;
	public int HP;
	// Use this for initialization
	void Start ()
	{
		insectCount = 10;
		maxCount = 100;
		attackersCount = 0;
		playerNumRace = 4;
		computerNumRace = 4;
		if (player) {
			playerNumRace = PlayerPrefs.GetInt ("SelectedRace");
		} else if (race) {
			computerNumRace = Random.Range (0, 4);
			while (computerNumRace == playerNumRace) {
				computerNumRace = Random.Range (0, 4);	
			}
		} else {
			SPD = 0;
			PPL = 0;
			DMG = 2;
			HP = 2;
		
		}
		if (playerNumRace == 0 || computerNumRace == 0) {
			SPD = 3;
			PPL = 1;
			DMG = 3;
			HP = 4;
		}
		if (playerNumRace == 1 || computerNumRace == 1) {
			SPD = 5;
			PPL = 2;
			DMG = 2;
			HP = 2;
		}
		if (playerNumRace == 2 || computerNumRace == 2) {
			SPD = 2;
			PPL = 0.5f;
			DMG = 4;
			HP = 5;
		}
		if (playerNumRace == 3 || computerNumRace == 3) {
			SPD = 4;
			PPL = 1.5f;
			DMG = 2;
			HP = 4;
		}
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
			insectCount = (float)maxCount;
		}
			
	}

	void OnMouseDrag ()
	{
		if (this.playerNumRace == PlayerPrefs.GetInt ("SelectedRace")) {
			GameManager.Instance.initialBuilding = this;
		}
	}

	void OnMouseUp ()
	{	
		if (this.playerNumRace == PlayerPrefs.GetInt ("SelectedRace") && GameManager.Instance.targetBuilding != this) {
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
			for (int i = 0; i < insectCount/2; i++) {
				createdInsect = Instantiate (GameManager.Instance.prefab [GameManager.Instance.playerNumRace], 
				new Vector3 (transform.position.x, 0, transform.position.z), 
				Quaternion.identity) as GameObject;
				insectCount--;
				attackersCount ++;
			}
		}
	}
}