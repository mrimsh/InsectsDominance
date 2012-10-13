using UnityEngine;
using System.Collections.Generic;

public class MidSceneObject : MonoBehaviour
{
#region Singletone tricks
	private static MidSceneObject midSceneObject;

	public static MidSceneObject Instance {
		get {
			if (midSceneObject == null) {
				midSceneObject = GameObject.Find ("MidSceneObject").GetComponent<MidSceneObject> ();
			}
			return midSceneObject;
		}
	}
#endregion

	public int[] selectedRaces;
	public Race[] races;
	public MapsDataCollection mapSaveCollection;
	public RacesDataCollection raceSaveCollection;
	public MapData selectedMap;
	public List<Player> playersInGame;
	void Start ()
	{
		Loader.Instance.SetStoragePath(Application.dataPath + "/Resources/GameValues/");
		mapSaveCollection = Loader.Instance.Load ("maps.xml", typeof(MapsDataCollection)) as MapsDataCollection;
		raceSaveCollection = Loader.Instance.Load ("races.xml", typeof(RacesDataCollection)) as RacesDataCollection;
	}

	void OnLevelWasLoaded (int level)
	{
		if (level == 1) {
			GameManager.Instance.AssembleLevel (mapSaveCollection.maps[0]);
		}
	}
}
	