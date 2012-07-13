using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player
{
	public int race;
	public Side side;
	public bool isHuman;
}

public enum Side 
{
	Neutral,
	AI,
	Player
}