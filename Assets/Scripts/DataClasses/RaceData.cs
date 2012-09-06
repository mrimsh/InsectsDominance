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