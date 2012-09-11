using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	bool b_IsShowMenu, b_IsShowGamePlay, b_IsShowOptions, b_IsShowRace;
	bool b_IsMusicOn, b_IsRedAnt, b_IsBlackAnt, b_IsBug, b_IsCockroach;
	// Use this for initialization
	public int selGridInt = 0;
	public string[] selStrings = new string[] {"I will play for Red Ants!", "Black Ants are the coolest", "Does anyone not like Bugs?", "Only Cockroaches! Only hardcore!"};

	void Start ()
	{
		MapsDataCollection mapSaveCollection = Loader.Instance.Load ("maps.xml", typeof(MapsDataCollection)) as MapsDataCollection;
		RacesDataCollection raceSaveCollection = Loader.Instance.Load ("races.xml", typeof(RacesDataCollection)) as RacesDataCollection;
		b_IsShowMenu = true;
		b_IsShowGamePlay = b_IsShowOptions = b_IsShowRace = false;
		b_IsMusicOn = b_IsRedAnt = true;
		b_IsBlackAnt = b_IsBug = b_IsCockroach = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnGUI ()
	{
		if (b_IsShowMenu) {
			GUILayout.BeginArea (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));
			GUILayout.BeginVertical ();
			if (GUILayout.Button ("New Game")) {
				b_IsShowMenu = false;
				b_IsShowRace = true;			
			}	
			GUILayout.FlexibleSpace ();
			if (GUILayout.Button ("Options")) {
				b_IsShowMenu = false;
				b_IsShowOptions = true;
			}
			GUILayout.FlexibleSpace ();
			if (GUILayout.Button ("Exit")) {
				Application.Quit ();		
			}
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		} else if (b_IsShowOptions) {
			GUILayout.BeginArea (new Rect (10, 10, Screen.width - 20, Screen.height - 20));
			GUILayout.BeginVertical ();
			GUILayout.FlexibleSpace ();
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			b_IsMusicOn = GUILayout.Toggle (b_IsMusicOn, "Switch on music");
			if (b_IsMusicOn) {
				//play music
			} else {
				//stop music
				
			}
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.FlexibleSpace ();
			if (GUILayout.Button ("Cancel", GUILayout.Width (100))) {
				b_IsShowOptions = false;
				b_IsShowMenu = true;
				//play game	
			}
			GUILayout.EndVertical ();
			GUILayout.EndArea ();
		} else if (b_IsShowRace) {
			
			GUILayout.BeginArea (new Rect (Screen.width / 3 - 40, Screen.height / 10 - 50, Screen.width / 2, Screen.height));
			
			GUILayout.FlexibleSpace ();
			selGridInt = GUILayout.SelectionGrid (selGridInt, selStrings, 1);
			PlayerPrefs.SetInt ("SelectedRace", selGridInt);
			GUILayout.FlexibleSpace ();
			GUILayout.EndArea ();
			GUILayout.BeginArea (new Rect (10, 10, Screen.width - 20, Screen.height - 20));
			
			GUILayout.FlexibleSpace ();
			if (GUILayout.Button ("Cancel", GUILayout.Width (100))) {
				b_IsShowOptions = false;
				b_IsShowMenu = true;
				
			}
			
			GUILayout.EndArea ();
		
			GUILayout.BeginArea (new Rect (Screen.width-110, 10, Screen.width - 20, Screen.height - 20));
			
			GUILayout.FlexibleSpace ();
			if (GUILayout.Button ("Start", GUILayout.Width (100))) {
				Application.LoadLevel (1);
				
			}
			
			GUILayout.EndArea ();
		
		}
	}
}