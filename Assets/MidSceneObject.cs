using UnityEngine;
using System.Collections;

public class MidSceneObject : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
	}
}
