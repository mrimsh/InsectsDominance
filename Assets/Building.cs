using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
	public GameObject insectPrefab;
	public int insectCount;
	public int maxCapacity;
	public Player playerOwner;
	private float lastPplIncreasedTime;
	
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
		if (insectCount < maxCapacity) {
			if (Time.time > lastPplIncreasedTime + playerOwner.race.ppl) {
				insectCount += 1;
				lastPplIncreasedTime = Time.time;
			}
		}
		if (insectCount > maxCapacity) {
			if (Time.time * (1 + (insectCount - maxCapacity) * 0.0001) > lastPplIncreasedTime + playerOwner.race.ppl) {
				insectCount -= 1;
				lastPplIncreasedTime = Time.time;
			}
		}
	}
	
	void OnGUI ()
	{
		// Getting object coordinates in world, as they drawed in screen
		Vector3 labelPosition = Camera.mainCamera.WorldToScreenPoint (transform.position);
		// Printing side, race and insects count of this builing over it on screen
		GUI.Label (new Rect (labelPosition.x - 25, Screen.height - labelPosition.y - 40, 100, 20), playerOwner.side.ToString ());
		GUI.Label (new Rect (labelPosition.x - 25, Screen.height - labelPosition.y - 20, 100, 20), playerOwner.race.name);
		GUI.Label (new Rect (labelPosition.x - 25, Screen.height - labelPosition.y, 100, 20), insectCount.ToString ());
	}
	
	void OnMouseDown ()
	{
		if (playerOwner.side == Side.Player) {
			// Drag started. Clearing list of buildings that sends squads and save first(this) building.
			GameManager.Instance.buildingsSendingSquad.Add (this);
			renderer.material.color = Color.green;
		}
	}

	void OnMouseExit ()
	{
		if (GameManager.Instance.targetBuilding != null && GameManager.Instance.targetBuilding.playerOwner.side == Side.AI) {
			GameManager.Instance.targetBuilding.renderer.material.color = Color.white;
		}	
		GameManager.Instance.targetBuilding = null;
	}

	void OnMouseOver ()
	{
		// Do nothing, if there is no buildongs in list(if there is no first building - means that it was not dragged)
		if (GameManager.Instance.buildingsSendingSquad.Count > 0) {
			if (playerOwner.side == Side.Player) {
				// If human player and not listed before - add to list and color.
				if (!GameManager.Instance.buildingsSendingSquad.Contains (this)) {
					GameManager.Instance.buildingsSendingSquad.Add (this);
					renderer.material.color = Color.green;
				}
			} else {
				// If AI player - save as target and color. But before restore color for previous target.
				if (GameManager.Instance.targetBuilding != null) {
					GameManager.Instance.targetBuilding.renderer.material.color = Color.white;
				}
				GameManager.Instance.targetBuilding = this;
				renderer.material.color = Color.red;
			}
		}
		GameManager.Instance.targetBuilding = this;	
	}
	
	void OnMouseUp ()
	{
		if (GameManager.Instance.targetBuilding != null) {
			for (int i = 0; i < GameManager.Instance.buildingsSendingSquad.Count; i++) {
				GameManager.Instance.buildingsSendingSquad [i].SendSquad ();
				GameManager.Instance.buildingsSendingSquad [i].renderer.material.color = Color.white;
			}
			GameManager.Instance.targetBuilding.renderer.material.color = Color.white;
			
			GameManager.Instance.buildingsSendingSquad.Clear ();
			GameManager.Instance.targetBuilding = null;
		} else {
			for (int i = 0; i < GameManager.Instance.buildingsSendingSquad.Count; i++) {
				GameManager.Instance.buildingsSendingSquad [i].renderer.material.color = Color.white;
			}
		}
		GameManager.Instance.buildingsSendingSquad.Clear ();
	}
	
	void SendSquad ()
	{
		Insect createdInsect;
		for (int i = 0; i < insectCount - 1; i++) {
			createdInsect = (Instantiate (insectPrefab, 
				new Vector3 (transform.position.x, 0, transform.position.z), 
				Quaternion.identity) as GameObject).GetComponent<Insect> ();
			createdInsect.initialBuilding = this;
			createdInsect.targetBuilding = GameManager.Instance.targetBuilding;
			insectCount--;
		}
	}
}