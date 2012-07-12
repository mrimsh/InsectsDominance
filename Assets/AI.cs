using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour
{
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject createdInsect;
		if (GameObject.Find ("Building 2").GetComponent<Building> ().insectCount > 
			GameObject.Find ("Building 2").GetComponent<Building> ().maxCount / 3) {
			for (int i = 0; i < GameObject.Find ("Building 2").GetComponent<Building> ().insectCount/2; i++) {
				createdInsect = Instantiate (GameManager.Instance.prefab [GameObject.Find ("Building 2").GetComponent<Building> ().computerNumRace], 
				new Vector3 (GameObject.Find ("Building 2").transform.position.x, 0, GameObject.Find ("Building 2").transform.position.z), 
				Quaternion.identity) as GameObject;
				GameObject.Find ("Building 2").GetComponent<Building> ().insectCount--;
				GameObject.Find ("Building 2").GetComponent<Building> ().attackersCount ++;
			}
			
		 
		}
	}
}
