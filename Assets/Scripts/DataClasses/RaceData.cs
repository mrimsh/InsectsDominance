using System;
using System.Collections.Generic;
using System.Xml.Serialization;

[Serializable]
[XmlRoot("RacesCollection")]
public class RacesDataCollection
{
	[XmlArray("Races")]
	[XmlArrayItem("RaceData")]
	public List<RaceData> races = new List<RaceData> ();
	
	public List<string> GetRacesNames()
	{
		List<string> ret = new List<string>();
		
		for (int i = 0; i < races.Count; i++)
		{
			ret.Add(races[i].name);
		}
		
		return ret;
	}
}

[Serializable]
public class RaceData
{
	public RaceData ()
	{
	}

	public RaceData (string _name)
	{
		name = _name;
	}
	
	[XmlAttribute("name")]
	public string name = "New Race";
	public float dmg;
	public float hp;
	public float ppl;
	public float spd;
}