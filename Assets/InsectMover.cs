using UnityEngine;
using System.Collections;

public class InsectMover : MonoBehaviour
{
	Vector3 q;
	float shiftLength = 0f;
	Vector3 shift;
	bool race ;
	GameObject a;

	void Start ()
	{
		shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
		
	}

	void GetNextPath ()
	{
		
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) { 
			GetNextPath ();
		}
		Vector3 direction = transform.position - GameManager.Instance.targetBuilding.transform.position;
		Vector3 nextMove = direction.normalized * Time.deltaTime * GameManager.Instance.initialBuilding.SPD;
		if (direction.magnitude >= nextMove.magnitude) {
			transform.position -= nextMove + (shift * Time.deltaTime);
			shiftLength += shift.magnitude * Time.deltaTime;
			if (shiftLength >= 1f) {
				shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
				shiftLength = 0;
			}
			
		} else {
			if (GameManager.Instance.initialBuilding.numRace == GameManager.Instance.targetBuilding.numRace) {
				GameManager.Instance.targetBuilding.insectCount ++;
				//Debug.Log("Plus");
			} else {
				//Debug.Log("Minus");
				if (GameManager.Instance.targetBuilding.insectCount * GameManager.Instance.targetBuilding.HP*GameManager.Instance.targetBuilding.DMG - GameManager.Instance.initialBuilding.DMG*GameManager.Instance.initialBuilding.HP >= 0) {
					
					Debug.Log("TB : " + GameManager.Instance.targetBuilding.insectCount * GameManager.Instance.targetBuilding.HP*GameManager.Instance.targetBuilding.DMG);
					Debug.Log("IB : " + GameManager.Instance.initialBuilding.attackersCount * GameManager.Instance.initialBuilding.DMG*GameManager.Instance.initialBuilding.HP);
					
					GameManager.Instance.targetBuilding.insectCount = (GameManager.Instance.targetBuilding.insectCount * GameManager.Instance.targetBuilding.HP*GameManager.Instance.targetBuilding.DMG -GameManager.Instance.initialBuilding.DMG*GameManager.Instance.initialBuilding.HP)/(GameManager.Instance.targetBuilding.HP*GameManager.Instance.targetBuilding.DMG);
				} else {
					Debug.Log("the seizure of the building!");	
				}
				GameManager.Instance.initialBuilding.attackersCount = 0;
				Destroy (gameObject);
			}
		}
	}
}