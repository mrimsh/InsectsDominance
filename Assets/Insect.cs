using UnityEngine;
using System.Collections;

public class Insect : MonoBehaviour
{
	float shiftLength = 0f;
	Vector3 shift;
	public Vector3 direction;
	public Vector3 nextMove;
	Vector3 target;
	[HideInInspector]
	public Building targetBuilding;
	[HideInInspector]
	public Building initialBuilding;
	
	void Start ()
	{
		target = targetBuilding.transform.position;
		shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));	
	}

	void Update ()
	{
		direction = transform.position - target;
		nextMove = direction.normalized * Time.deltaTime * initialBuilding.playerOwner.race.spd; 
		if (direction.magnitude >= nextMove.magnitude) {
			transform.position -= nextMove + (shift * Time.deltaTime);
			shiftLength += shift.magnitude * Time.deltaTime;
			if (shiftLength >= 1f) {
				shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
				shiftLength = 0;
			}
		} else {
			if (targetBuilding.playerOwner.race.numRace == 
					initialBuilding.playerOwner.race.numRace) {
				targetBuilding.insectCount ++;
				//Debug.Log ("Plus");
			} else {
				//Debug.Log ("Minus");
				if (targetBuilding.insectCount * targetBuilding.playerOwner.race.hp * targetBuilding.playerOwner.race.dmg - initialBuilding.playerOwner.race.dmg * initialBuilding.playerOwner.race.hp >= 0) {
					targetBuilding.insectCount = (targetBuilding.insectCount * targetBuilding.playerOwner.race.hp * targetBuilding.playerOwner.race.dmg - initialBuilding.playerOwner.race.dmg * initialBuilding.playerOwner.race.hp) / (targetBuilding.playerOwner.race.hp * targetBuilding.playerOwner.race.dmg);
				} else {
					//Debug.Log ("The seizure of the building!");	
					targetBuilding.playerOwner.side = initialBuilding.playerOwner.side;
					targetBuilding.playerOwner.race = GameManager.Instance.races [initialBuilding.playerOwner.race.numRace]; 
					//changes in the building
				}
			}
			Destroy (gameObject);
		}
		
	}
}