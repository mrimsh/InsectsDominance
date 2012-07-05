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
			float cloneX = Random.Range (-4.5f, 4.5f);
			float cloneZ = Random.Range (-4.5f, 4.5f);
			Instantiate (prefab [numRace], new Vector3 (cloneX, 0, cloneZ), Quaternion.identity);
		}
	}
}