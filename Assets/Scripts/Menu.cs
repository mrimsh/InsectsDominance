using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu : MonoBehaviour
{
	public UIPanel MainMenu;
	public UIPanel ChoiseMenu;
	public UIPanel OptionsMenu;
	public UIPanel pnl_NewGameMenu;
	public UIPanel thisPanel;
	public UIPopupList poplst_map;
	public GameObject lbl_player, poplst_PlayerRace;
	/// <summary>
	/// List of procedurally generated UI Labels of players.
	/// </summary>
	private List<UILabel> playerLabels = new List<UILabel> ();
	/// <summary>
	/// List of procedurally generated UI PopLists of player races.
	/// </summary>
	private List<UIPopupList> playerRacePopLists = new List<UIPopupList> ();
	
	void Awake ()
	{
		thisPanel = MainMenu;
		moveForw (thisPanel);
		DontDestroyOnLoad (GameObject.Find ("MidSceneObject"));
	}
	
	void Start ()
	{
		
	}
	
	void moveForw (UIPanel panel)
	{
		panel.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		thisPanel = panel;
	}

	void moveBack ()
	{
		thisPanel.transform.localPosition = new Vector3 (2000.0f, 0.0f, 0.0f);
	}

	void OnStartButton ()
	{
		moveBack ();
		poplst_map.items.Clear ();
		foreach (MapData maps in MidSceneObject.Instance.mapSaveCollection.maps) {
			poplst_map.items.Add (maps.name);
		}
		poplst_map.selection = poplst_map.items [0];
		moveForw (pnl_NewGameMenu);
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
	
	/// <summary>
	/// Raises the map selection change event.
	/// </summary>
	/// <param name='sender'>
	/// Poplist that called this message.
	/// </param>
	/// 
	void OnMapSelectionChange (UIPopupList sender)
	{
		// Finds map from list, with name, that equals to poplist selection
		MapData selectedMap = MidSceneObject.Instance.mapSaveCollection.maps.Find (delegate(MapData map) {
			return map.name == sender.selection;
		});
		
		// Remove all player labels and poplists
		for (int i = 0; i < playerLabels.Count; i++) {
			Destroy (playerLabels [i].gameObject);
			Destroy (playerRacePopLists [i].gameObject);
		}
		playerLabels.Clear ();
		playerRacePopLists.Clear ();
		
		if (selectedMap != null) {
			// Create label and poplist for each player in map
			for (int i = 0; i < selectedMap.players + 1; i++) {
				// Label
				UILabel newLabel = (Instantiate (lbl_player) as GameObject).GetComponent<UILabel> ();
				newLabel.name = "lbl_CPUPlayer " + i;
				newLabel.transform.parent = pnl_NewGameMenu.transform;
				newLabel.transform.localPosition = lbl_player.transform.position - new Vector3 (0, 30 * i, 0);
				newLabel.transform.localRotation = Quaternion.identity;
				newLabel.transform.localScale = lbl_player.transform.lossyScale;
				newLabel.text = (i == 0) ? "Human Player" : "Opponent" + i;
				playerLabels.Add (newLabel);
				// PopList
				UIPopupList newPopList = (Instantiate (poplst_PlayerRace) as GameObject).GetComponent<UIPopupList> ();
				newPopList.name = "poplst_CPUPlayer " + i;
				newPopList.transform.parent = pnl_NewGameMenu.transform;
				newPopList.transform.localPosition = poplst_PlayerRace.transform.position - new Vector3 (0, 30 * i, 0);
				newPopList.transform.localRotation = Quaternion.identity;
				newPopList.transform.localScale = poplst_PlayerRace.transform.lossyScale;
				newPopList.items = MidSceneObject.Instance.raceSaveCollection.GetRacesNames ();
				newPopList.selection = newPopList.items [0];
				newPopList.eventReceiver = gameObject;
				playerRacePopLists.Add (newPopList);
			}
			// Human Player name/text correction
			playerLabels [0].name = "lbl_HumanPlayer";
			playerLabels [0].text = "Human Player";
			playerRacePopLists [0].name = "poplst_HumanPlayer";
			// Neutral Player name/text correction
			playerLabels [1].name = "lbl_NeutralPlayer";
			playerLabels [1].text = "Neutral Player";
			playerRacePopLists [1].name = "poplst_NeutralPlayer";
		}
	}
	
	void OnPlayerRaceSelectionChange (UIPopupList sender)
	{
		// Any actions on race selection change?
		// Poplist can be determined by sender.name checking.
	}
	
	void OnStartGameButton ()
	{
		Player newPlayer;
		
		// Player init
		newPlayer = new Player ();
		newPlayer.race = MidSceneObject.Instance.raceSaveCollection.races.Find (delegate(RaceData race) {
			return race.name == playerRacePopLists [0].selection;
		});
		newPlayer.side = Side.Player;
		MidSceneObject.Instance.playersInGame.Add (newPlayer);
		// Neutral init
		newPlayer = new Player ();
		newPlayer.race = MidSceneObject.Instance.raceSaveCollection.races.Find (delegate(RaceData race) {
			return race.name == playerRacePopLists [1].selection;
		});
		newPlayer.side = Side.Neutral;
		MidSceneObject.Instance.playersInGame.Add (newPlayer);
		// Last enemies init
		for (int i = 2; i < playerRacePopLists.Count; i++) {
			newPlayer = new Player ();
			newPlayer.race = MidSceneObject.Instance.raceSaveCollection.races.Find (delegate(RaceData race) {
				return race.name == playerRacePopLists [i].selection;
			});
			newPlayer.side = Side.AI;
			MidSceneObject.Instance.playersInGame.Add (newPlayer);
		}
		
		// test
		MidSceneObject asd = MidSceneObject.Instance;
		
		Application.LoadLevel ("Game");
	}
}