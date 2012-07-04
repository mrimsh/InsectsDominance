using UnityEngine;
using System.Collections;

public class ClickMover : MonoBehaviour
{
	Vector3 norm, p, q;

	void Start ()
	{
		func ();
		
	}

	void func ()
	{
		if (Input.GetButtonDown ("Fire1")) { 
			p = Camera.mainCamera.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0));
			p = new Vector3 (p.x, 0, p.z);
			q = p;
			p = new Vector3 (transform.position.x - p.x, 0, transform.position.z - p.z);
			norm = p.normalized;
		}
	}

	void Update ()
	{
		Vector3 nextMove = norm * Time.deltaTime;
		func ();
			
		if (Mathf.Abs (transform.position.magnitude - q.magnitude) > nextMove.magnitude) {
			transform.position -= nextMove;
							
		}
	}
}