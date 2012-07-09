using UnityEngine;
using System.Collections;

public class InsectMover : MonoBehaviour
{
	public Building target;
	Vector3 q;
	float shiftLength = 0f;
	Vector3 shift;
	GameObject race ;
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
		
		
		Vector3 direction = transform.position - target.transform.position;
		Vector3 nextMove = direction.normalized * Time.deltaTime * GameManager.Instance.movementSpeed;
		
		if (direction.magnitude >= nextMove.magnitude) {
			transform.position -= nextMove + (shift * Time.deltaTime);
			shiftLength += shift.magnitude * Time.deltaTime;
			if (shiftLength >= 1f) {
				shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
				shiftLength = 0;
			}
			
		} else {
			if (true/*race.GetComponent<Building>().race*/) {
				target.insectCount++;
				
			} else {
				target.insectCount--;
			}
			
			Destroy (gameObject);
		
		}
	}
}