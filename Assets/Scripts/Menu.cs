using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	public UIPanel MainMenu;
	public UIPanel ChoiseMenu;
	public UIPanel OptionsMenu;
	public UIPanel thisPanel;
	
	void Awake ()
	{
		thisPanel = MainMenu;
		moveForw (thisPanel);
	}
	
	void Start ()
	{
		
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
		moveBack ();
		moveForw (ChoiseMenu);
	}

	void OnBackButton ()
	{
		moveBack ();
		moveForw (MainMenu);
	}
	
	void OnOptionsButton ()
	{
		moveBack ();
		moveForw (OptionsMenu);
	}

	void OnLetsGoButton ()
	{
		/* TEMPORARY PLAYERS INSTANTIATING */
		Player newPlayer = new Player();
		newPlayer.race = MidSceneObject.Instance.raceSaveCollection.races[1];
		newPlayer.side = Side.Player;
		MidSceneObject.Instance.playersInGame.Add (newPlayer);
		newPlayer = new Player();
		newPlayer.race = MidSceneObject.Instance.raceSaveCollection.races[0];
		newPlayer.side = Side.Neutral;
		MidSceneObject.Instance.playersInGame.Add (newPlayer);
		newPlayer = new Player();
		newPlayer.race = MidSceneObject.Instance.raceSaveCollection.races[2];
		newPlayer.side = Side.AI;
		MidSceneObject.Instance.playersInGame.Add (newPlayer);
		/* players */
		
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