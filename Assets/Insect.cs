using UnityEngine;
using System.Collections;

public class Insect : MonoBehaviour
{
	float shiftLength = 0f;
	Vector3 shift;
	public Vector3 direction;
	public Vector3 nextMove;
	Vector3 target;

	void Start ()
	{
		target = GameManager.Instance.targetBuilding.transform.position;
		shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));	
	}

	void Update ()
	{
		
		direction = transform.position - target;
		nextMove = direction.normalized * Time.deltaTime * GameManager.Instance.initialBuilding.playerOwner.race.spd; 
		
		
		if (direction.magnitude >= nextMove.magnitude) {
			
			transform.position -= nextMove + (shift * Time.deltaTime);

			shiftLength += shift.magnitude * Time.deltaTime;
			if (shiftLength >= 1f) {
				shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
				shiftLength = 0;
			}
		} else {
			
			if (GameManager.Instance.targetBuilding.playerOwner.race.numRace == 
					GameManager.Instance.initialBuilding.playerOwner.race.numRace) {
				GameManager.Instance.targetBuilding.insectCount ++;
				//Debug.Log ("Plus");
			} else {
				//Debug.Log ("Minus");
				if (GameManager.Instance.targetBuilding.insectCount * GameManager.Instance.targetBuilding.playerOwner.race.hp * GameManager.Instance.targetBuilding.playerOwner.race.dmg - GameManager.Instance.initialBuilding.playerOwner.race.dmg * GameManager.Instance.initialBuilding.playerOwner.race.hp >= 0) {
					GameManager.Instance.targetBuilding.insectCount = (GameManager.Instance.targetBuilding.insectCount * GameManager.Instance.targetBuilding.playerOwner.race.hp * GameManager.Instance.targetBuilding.playerOwner.race.dmg - GameManager.Instance.initialBuilding.playerOwner.race.dmg * GameManager.Instance.initialBuilding.playerOwner.race.hp) / (GameManager.Instance.targetBuilding.playerOwner.race.hp * GameManager.Instance.targetBuilding.playerOwner.race.dmg);
				} else {
					//Debug.Log ("The seizure of the building!");	
					GameManager.Instance.targetBuilding.playerOwner.side = Side.Player;
					GameManager.Instance.targetBuilding.playerOwner.race.numRace = PlayerPrefs.GetInt ("SelectedRace");
					//changes in the building
				}
				GameManager.Instance.initialBuilding.attackersCount = 0;

			}
			
			
			Destroy (gameObject);
		}
	}
}