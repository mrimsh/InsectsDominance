using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player
{
	public RaceData race;
	public Side side;

}
	
public enum Side
{
	Neutral,
	AI,
	Player
}


	