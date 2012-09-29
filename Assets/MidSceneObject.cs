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

	void OnLevelWasLoaded (int level)
	{

		if (level == 1) {
			// а тут пишем код, который нужно выполнять, когда загрузилась сцена под индексом 1 в Build Setting (ctrl+shift+B)
		}
	}
}
	