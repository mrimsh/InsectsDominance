using UnityEngine;
using System.Collections;

public class ClickMover : MonoBehaviour
{
	Vector3 target, q;
	float shiftLength = 0f;
	Vector3 shift;
	public int speed;
	void Start ()
	{
		shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
	}

	void GetNextPath ()
	{
		target = Camera.mainCamera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
		target = new Vector3 (target.x, 0, target.z);
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Fire1")) { 
			GetNextPath ();
		}
		
		
		Vector3 direction = transform.position - target;
		Vector3 nextMove = direction.normalized * Time.deltaTime*speed;
		
		if (direction.magnitude >= nextMove.magnitude) {
			transform.position -= nextMove + (shift * Time.deltaTime);
			shiftLength += shift.magnitude * Time.deltaTime;
			if (shiftLength >= 1f) {
				shift = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
				shiftLength = 0;
			}
			
		} else {
			
		
		}
	}
}