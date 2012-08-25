using UnityEngine;
using System.Collections;
[System.Serializable]
public class Race
{
	public string name;
	public int dmg, hp, spd;
	public float ppl;
	public int numRace;
	void Start ()
	{
		numRace = PlayerPrefs.GetInt ("SelectedRace");
		
		if (numRace == 0) {
			name = "Red Ants";
			dmg = 3;
			hp = 2;
			spd = 2;
			ppl = 1f;
		}
		if (numRace == 1) {
			name = "Black Ants";
			dmg = 2;
			hp = 2;
			spd = 4;
			ppl = 2f;
		}
		if (numRace == 2) {
			name = "Bugs";
			dmg = 4;
			hp = 3;
			spd = 2;
			ppl = 0.5f;
		}
		if (numRace == 3) {
			name = "Cockroaches";
			dmg = 2;
			hp = 4;
			spd = 3;
			ppl = 1.5f;
		}
	}
}