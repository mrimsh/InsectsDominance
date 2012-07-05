using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{

	public GameObject prefab;

	public void Start ()
	{	
		spawn ();
	}

	void spawn ()
	{
		float prefabX = prefab.transform.position.x;
		float prefabZ = prefab.transform.position.z;

		for (int i=0; i<10; i++) {
			float cloneX = Random.Range (-4.5f, 4.5f);
			float cloneZ = Random.Range (-4.5f, 4.5f);

			//Vector3 distance = new Vector3 (cloneX - prefabX, 0, cloneZ - prefabZ);

			
			Instantiate (prefab, new Vector3 (cloneX, 0, cloneZ), Quaternion.identity);
		}
	}
}