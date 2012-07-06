using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{
	public GameObject[] prefab;
	public int numRace;

	public void Start ()
	{	
		numRace = PlayerPrefs.GetInt ("SelectedRace");
		spawn ();
	}

	void spawn ()
	{
		float prefabX = prefab [numRace].transform.position.x;
		float prefabZ = prefab [numRace].transform.position.z;
		for (int i=0; i<10; i++) {
			float cloneX = prefabX;
			float cloneZ = prefabZ;
			Instantiate (prefab [numRace], new Vector3 (cloneX, 0, cloneZ), Quaternion.identity);
		}
	}
}