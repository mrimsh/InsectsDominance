using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
	public float insectCount;
	int maxCount;
	public bool race;
	// Use this for initialization
	void Start ()
	{
		insectCount = 10;
		maxCount = 100;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (race) {
			if (insectCount < maxCount) {		
				insectCount += Time.deltaTime * GameManager.Instance.reproductionSpeed;
			}
		}
		if (insectCount > maxCount) {
			insectCount = maxCount;
		}
			
	}
	
	void OnMouseDrag ()
	{
		GameManager.Instance.targetBuilding = this;
	}

	void OnMouseUp ()
	{
		
		if (GameManager.Instance.targetBuilding != this) {
			SendSquad ();
		}
	}

	void OnMouseOver ()
	{
		GameManager.Instance.targetBuilding = this;
		
	}

	void SendSquad ()
	{
		GameObject createdInsect;
		if (race && insectCount > 0) {
			for (int i=0; i<insectCount/2; i++) {
				createdInsect = Instantiate (GameManager.Instance.prefab [GameManager.Instance.numRace], 
				new Vector3 (transform.position.x, 0, transform.position.z), 
				Quaternion.identity) as GameObject;
				insectCount--;
				createdInsect.GetComponent<InsectMover> ().target = GameManager.Instance.targetBuilding;
			}
		}
		
		
	}
	
	
}
