using UnityEngine;
using System.Collections;

public class InsectMover : MonoBehaviour
{
	float shiftLength = 0f;
	Vector3 shift;
	bool race ;
	public Vector3 direction;
	public Vector3 nextMove;
	bool player;
	Vector3 target;

	void Start ()
	{
		if (transform.position.x == GameObject.Find ("Building 1").GetComponent<Transform> ().position.x && 
			transform.position.z == GameObject.Find ("Building 1").GetComponent<Transform> ().position.z) {
			player = true;
			target = GameManager.Instance.targetBuilding.transform.position;
		} else {
			player = false;
		}
		shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
	}

	void Update ()
	{
		if (player) {
			direction = transform.position - target;
		} else {
			direction = transform.position - GameObject.Find ("Building 1").GetComponent<Transform> ().position;
		}
		if (player) {
			nextMove = direction.normalized * Time.deltaTime * GameManager.Instance.initialBuilding.SPD; 
		} else {
			nextMove = direction.normalized * Time.deltaTime * GameObject.Find ("Building 2").GetComponent<Building> ().SPD;
		}
		
		if (direction.magnitude >= nextMove.magnitude) {
			
			transform.position -= nextMove + (shift * Time.deltaTime);

			shiftLength += shift.magnitude * Time.deltaTime;
			if (shiftLength >= 1f) {
				shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
				shiftLength = 0;
			}
		} else {
			if (player) {
				if (GameManager.Instance.targetBuilding.player) {
					GameManager.Instance.targetBuilding.insectCount ++;
					//Debug.Log ("Plus");
				} else {
					//Debug.Log ("Minus");
					if (GameManager.Instance.targetBuilding.insectCount * GameManager.Instance.targetBuilding.HP * GameManager.Instance.targetBuilding.DMG - GameManager.Instance.initialBuilding.DMG * GameManager.Instance.initialBuilding.HP >= 0) {
						GameManager.Instance.targetBuilding.insectCount = (GameManager.Instance.targetBuilding.insectCount * GameManager.Instance.targetBuilding.HP * GameManager.Instance.targetBuilding.DMG - GameManager.Instance.initialBuilding.DMG * GameManager.Instance.initialBuilding.HP) / (GameManager.Instance.targetBuilding.HP * GameManager.Instance.targetBuilding.DMG);
					} else {
						Debug.Log ("The seizure of the building!");	
						GameManager.Instance.targetBuilding.player = true;
						GameManager.Instance.targetBuilding.playerNumRace = PlayerPrefs.GetInt ("SelectedRace");
						//changes in the building
					}
					GameManager.Instance.initialBuilding.attackersCount = 0;
					GameObject.Find ("Building 2").GetComponent<Building> ().attackersCount = 0;
				}
			} else {
				if (GameObject.Find ("Building 1").GetComponent<Building> ().insectCount * GameObject.Find ("Building 1").GetComponent<Building> ().HP * GameObject.Find ("Building 1").GetComponent<Building> ().DMG - GameObject.Find ("Building 2").GetComponent<Building> ().DMG * GameObject.Find ("Building 2").GetComponent<Building> ().HP >= 0) {
					GameObject.Find ("Building 1").GetComponent<Building> ().insectCount = (GameObject.Find ("Building 1").GetComponent<Building> ().insectCount * GameObject.Find ("Building 1").GetComponent<Building> ().HP * GameObject.Find ("Building 1").GetComponent<Building> ().DMG - GameObject.Find ("Building 2").GetComponent<Building> ().DMG * GameObject.Find ("Building 2").GetComponent<Building> ().HP) / (GameObject.Find ("Building 1").GetComponent<Building> ().HP * GameObject.Find ("Building 1").GetComponent<Building> ().DMG);
				} else {
					Debug.Log ("The seizure of the building! (computer win)");	
					GameObject.Find ("Building 1").GetComponent<Building> ().player = false;
					GameObject.Find ("Building 1").GetComponent<Building> ().computerNumRace = GameObject.Find ("Building 2").GetComponent<Building> ().computerNumRace;
					GameObject.Find ("Building 1").GetComponent<Building> ().playerNumRace = 4;
					
					//changes in the building
				}
				GameObject.Find ("Building 2").GetComponent<Building> ().attackersCount = 0;
			}
			
			Destroy (gameObject);
		}
	}
}