using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
	public int insectCount;
	public int maxCapacity;
	public Player playerOwner;
	public float dmgBonus;
	public float hpBonus;
	public float pplBonus;
	public float spdBonus;
	// Use this for initialization
	void Start ()
	{
		
	}										
	
	// Update is called once per frame
	void Update ()
	{
			
		if (race) {
			if (insectCount < maxCapacity) {		
				insectCount += Time.deltaTime * PPL;
			}
		}
		if (insectCount > maxCapacity) {
			insectCount = (float)maxCapacity;
		}
			
	}

	void OnMouseDrag ()
	{
		if (this.playerNumRace == PlayerPrefs.GetInt ("SelectedRace")) {
			GameManager.Instance.initialBuilding = this;
		}
	}

	void OnMouseUp ()
	{	
		if (this.playerNumRace == PlayerPrefs.GetInt ("SelectedRace") && GameManager.Instance.targetBuilding != this) {
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
			for (int i = 0; i < insectCount/2; i++) {
				createdInsect = Instantiate (GameManager.Instance.prefab [GameManager.Instance.playerNumRace], 
				new Vector3 (transform.position.x, 0, transform.position.z), 
				Quaternion.identity) as GameObject;
				insectCount--;
				attackersCount ++;
			}
		}
	}

	
}