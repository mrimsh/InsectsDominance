using UnityEngine;
using System.Collections;

public class AntMover : MonoBehaviour
{
	Vector3 pos, norm;

	void Start ()
	{
		position ();
	}

	void position ()
	{
		pos = new Vector3 (Random.Range (-4.5f, 4.5f), 0, Random.Range (-4.5f, 4.5f));
		pos = new Vector3 (transform.position.x - pos.x, 0, transform.position.z - pos.z);
		norm = pos.normalized;
	}

	void Update ()
	{
		Vector3 nextMove = norm * Time.deltaTime;
		
		if (transform.position.x - nextMove.x < -4.5f ||
			transform.position.x - nextMove.x > 4.5f ||
			transform.position.z - nextMove.z < -4.5f ||
			transform.position.z - nextMove.z > 4.5f) {	
			position ();
			Debug.Log ("Next target: " + pos);
		} else {
			transform.position -= nextMove;
		}
			
	}
}
