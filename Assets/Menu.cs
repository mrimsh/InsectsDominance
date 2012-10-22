using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	public UIPanel MainMenu;
	public UIPanel MapChoise;
	public UIPanel TestRaceChoise;
	public UIPanel OptionsMenu;
	public UIPanel thisPanel;
	bool isMapChoosen;

	void Awake ()
	{
		thisPanel = MainMenu;
		moveForw (thisPanel);
		isMapChoosen = false;
	}
	
	void Start ()
	{
		//MidSceneObject.Instance.mapSaveCollection = Loader.Instance.Load ("maps.xml", typeof(MapsDataCollection)) as MapsDataCollection;
		//MidSceneObject.Instance.raceSaveCollection = Loader.Instance.Load ("races.xml", typeof(RacesDataCollection)) as RacesDataCollection;
	}

	void moveForw (UIPanel panel)
	{
		panel.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
		thisPanel = panel;
	}

	void moveBack ()
	{
		thisPanel.transform.position = new Vector3 (5.0f, 0.0f, 0.0f);
	}
	
	/*void moveSecretButton ()
	{
		if (isMapChoosen) {
			GameObject.Find("ChooseRaceButton").transform.position = new Vector3 (0.0f, 0.0f, 0.0f);			
		}
		else{
			GameObject.Find("ChooseRaceButton").transform.position = new Vector3 (5.0f, 0.0f, 0.0f);
		}
	}*/
	
	void setRace (string raceName, int index)
	{
		switch (raceName) {
		case "Red Ants":
			MidSceneObject.Instance.selectedRaces [index] = 0;
			break;
		case "Black Ants":
			MidSceneObject.Instance.selectedRaces [index] = 1;
			break;
		case "Bugs":
			MidSceneObject.Instance.selectedRaces [index] = 2;
			break;
		case "Cockroaches":
			MidSceneObject.Instance.selectedRaces [index] = 3;
			break;
		default:
			MidSceneObject.Instance.selectedRaces [index] = 4;
			break;
		} 
	}
	
	void setMap (string mapName)
	{
		switch (mapName) {
		case "Test Map":
			GameObject.Find("ChooseRaceButton").transform.position = new Vector3 (0.0f, -0.6483790523690773f, 0.0f);
			break;
		default:
			GameObject.Find("ChooseRaceButton").transform.position = new Vector3 (10.0f, -0.6483790523690773f, 0.0f);
			break;
		}
	}

	void OnStartButton ()
	{
		moveBack ();
		moveForw (MapChoise);
	}

	void OnBackButton ()
	{
		moveBack ();
		moveForw (MainMenu);
	}
	
	void OnChooseRaceButton ()
	{
		moveBack ();
		moveForw (TestRaceChoise);
	}

	void OnOptionsButton ()
	{
		moveBack ();
		moveForw (OptionsMenu);
	}

	void OnLetsGoButton ()
	{
		DontDestroyOnLoad (GameObject.Find ("MidSceneObject"));
		Application.LoadLevel (1);
	}

	void OnPlayerSelectionChange ()
	{
		setRace (GameObject.Find ("PlayerRace").GetComponent<UIPopupList> ().selection, 0);
	}

	void OnEnemySelectionChange ()
	{
		setRace (GameObject.Find ("EnemyRace").GetComponent<UIPopupList> ().selection, 1);
	}
	
	void OnMapSelectionChange ()
	{
		setMap (GameObject.Find ("MapList").GetComponent<UIPopupList> ().selection);
	}

	void Update ()
	{
		Debug.Log (isMapChoosen);
	}
}