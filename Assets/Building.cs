using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
	public GameObject insectPrefab;
	float falseInsectCount;
	public int insectCount;
	public int maxCapacity;
	public Player playerOwner;
	public float dmgBonus;
	public float hpBonus;
	public float pplBonus;
	public float spdBonus;
	public int attackersCount;
	// Use this for initialization
	void Start ()
	{
		
	}										
	
	// Update is called once per frame
	void Update ()
	{	
		falseInsectCount += playerOwner.race.ppl * pplBonus * Time.deltaTime;
		if (Mathf.Ceil (falseInsectCount) - falseInsectCount <= 0.5 && insectCount < maxCapacity && playerOwner.side != Side.Neutral) {
			insectCount += 1;
			falseInsectCount = 0;
		}
		
	}

	void OnMouseDrag ()
	{
		if (playerOwner.side == Side.Player) {
			GameManager.Instance.initialBuilding = this;
		}
		
	}

	void OnMouseUp ()
	{	
		if (GameManager.Instance.targetBuilding != null && GameManager.Instance.initialBuilding != null) {
			SendSquad ();
			
		}
	}

	void OnMouseOver ()
	{
		if (GameManager.Instance.initialBuilding != this) {
			GameManager.Instance.targetBuilding = this;
		}
	}

	void SendSquad ()
	{
		GameObject createdInsect;
		for (int i = 0; i < insectCount/2; i++) {
			createdInsect = Instantiate (insectPrefab, 
				new Vector3 (transform.position.x, 0, transform.position.z), 
				Quaternion.identity) as GameObject;
			insectCount--;
			attackersCount ++;
		}
		
	//	GameManager.Instance.targetBuilding = null;
	//	GameManager.Instance.initialBuilding = null;
	}

	
}