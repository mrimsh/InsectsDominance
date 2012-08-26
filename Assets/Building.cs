using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
	public GameObject insectPrefab;
	float falseInsectCount;
	public int insectCount;
	public int maxCapacity;
	public Player playerOwner;
	public int attackersCount;
	// Use this for initialization
	void Start ()
	{
		if (playerOwner.side == Side.Player) {
			playerOwner.race = GameManager.Instance.races [PlayerPrefs.GetInt ("SelectedRace")];//GameManager.Instance.selectedRaces [0]];
		} else {
			if (playerOwner.side == Side.AI) {
				playerOwner.race = GameManager.Instance.races [GameManager.Instance.selectedRaces [1]];
			} else {
				playerOwner.race = GameManager.Instance.races [4];
			}
		}
	}										
	// Update is called once per frame
	void Update ()
	{	
		falseInsectCount += playerOwner.race.ppl * playerOwner.race.pplBonus * Time.deltaTime;
		if (1 - falseInsectCount <= 0.5 && insectCount < maxCapacity && playerOwner.side != Side.Neutral) {
			insectCount += 1;
			falseInsectCount = 0;
		}
		if (insectCount > maxCapacity) {
			falseInsectCount += (Time.deltaTime * (insectCount - maxCapacity) % maxCapacity) / 20;
			if (1 - falseInsectCount <= 0.5) {
				insectCount -= 1;
				falseInsectCount = 0;
			}
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
		for (int i = 0; i < insectCount; i++) {
			createdInsect = Instantiate (insectPrefab, 
				new Vector3 (transform.position.x, 0, transform.position.z), 
				Quaternion.identity) as GameObject;
			insectCount--;
			attackersCount ++;
		}
		
		//GameManager.Instance.targetBuilding = null;
		//GameManager.Instance.initialBuilding = null;
	}

	
}