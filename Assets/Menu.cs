using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	bool b_IsShowMenu,b_IsShowGamePlay, b_IsShowOptions;
	bool b_IsMusicOn;
	// Use this for initialization
	void Start () {
		b_IsShowMenu = true;
		b_IsShowGamePlay = b_IsShowOptions = false;
		b_IsMusicOn = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		if (b_IsShowMenu){
			GUILayout.BeginArea(new Rect(Screen.width/2-50,	Screen.height/2-50,100,100));
			GUILayout.BeginVertical();
			if (GUILayout.Button("Start game")){
				b_IsShowMenu = false;
				b_IsShowGamePlay = true;
				
				
			}	
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Options")){
				b_IsShowMenu = false;
				b_IsShowOptions = true;
			}
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Exit")){
				Application.Quit();		
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}else if(b_IsShowGamePlay){
			GUILayout.BeginArea(new Rect(10, 10, Screen.width-20, Screen.height-20));
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Start game")){
				//play game	
				Application.LoadLevel(1);
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Cancel",GUILayout.Width(100))){
				b_IsShowGamePlay = false;
				b_IsShowMenu = true;
				//play game	
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}else if(b_IsShowOptions){
			GUILayout.BeginArea(new Rect(10, 10, Screen.width-20, Screen.height-20));
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			b_IsMusicOn = GUILayout.Toggle(b_IsMusicOn, "Switch on music");
			if (b_IsMusicOn){
				//play music
			}else{
				//stop music
				
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Cancel",GUILayout.Width(100))){
				b_IsShowOptions = false;
				b_IsShowMenu = true;
				//play game	
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
		}
		
		
	}
}
