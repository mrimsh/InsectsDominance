using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
	public GameObject insectPrefab;
	float falseInsectCount;
	public int insectCount;
	public int maxCapacity;
	public Player playerOwner;
	
	// Use this for initialization
	void Start ()
	{
		if (playerOwner.side == Side.Player) {
			playerOwner.race = GameManager.Instance.races [PlayerPrefs.GetInt ("SelectedRace")];
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
			GameManager.Instance.drag = true;
		}
	}

	void OnMouseExit ()
	{
		GameManager.Instance.targetBuilding = null;
	}

	void OnMouseUp ()
	{	
		if (GameManager.Instance.targetBuilding != null && GameManager.Instance.initialBuildings.Count > 0
			&& playerOwner.side == Side.Player) {
			int count = GameManager.Instance.initialBuildings.Count;
			for (int i = 0; i < count; i++) {
				GameManager.Instance.initialBuilding = GameManager.Instance.initialBuildings.Pop ();
				//Debug.Log (GameManager.Instance.initialBuilding);
				SendSquad ();
				
			}
		}
		GameManager.Instance.drag = false;
	}

	void OnMouseOver ()
	{			
		if (playerOwner.side == Side.Player && GameManager.Instance.drag) {
			if (!GameManager.Instance.initialBuildings.Contains (this)) {
				GameManager.Instance.initialBuildings.Push (this);
			}
		} else {
			GameManager.Instance.targetBuilding = this;
		}
	}

	void SendSquad ()
	{
		GameObject createdInsect;
		for (int i = 0; i < insectCount - 1; i++) {
			createdInsect = Instantiate (insectPrefab, 
				new Vector3 (transform.position.x, 0, transform.position.z), 
				Quaternion.identity) as GameObject;
			insectCount--;
		}
	}
}