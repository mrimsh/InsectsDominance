using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	public UIPanel MainMenu;
	public UIPanel ChoiseMenu;
	
	void Stert ()
	{
		MapsDataCollection mapSaveCollection = Loader.Instance.Load ("maps.xml", typeof(MapsDataCollection)) as MapsDataCollection;
		RacesDataCollection raceSaveCollection = Loader.Instance.Load ("races.xml", typeof(RacesDataCollection)) as RacesDataCollection;
	}

	void moveForw (UIPanel panel)
	{
		panel.transform.position = new Vector3 (0.0f, 0.0f, 0.0f);
	}

	void moveBack (UIPanel panel)
	{
		panel.transform.position = new Vector3 (5.0f, 0.0f, 0.0f);
	}

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

	void OnStartButton ()
	{
		moveBack (MainMenu);
		moveForw (ChoiseMenu);
	}

	void OnBackButton ()
	{
		moveBack (ChoiseMenu);
		moveForw (MainMenu);
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
}