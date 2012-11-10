using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

[Serializable]
[XmlRoot("MapsCollection")]
public class MapsDataCollection
{
	[XmlArray("Maps")]
	[XmlArrayItem("MapData")]
	public List<MapData> maps = new List<MapData> ();
}

[Serializable]
public class MapData
{
	public MapData ()
	{
	}

	public MapData (string _name)
	{
		name = _name;
	}
	
	[XmlAttribute("name")]
	public string name = "New Map";
	
	public int players = 2;
	
	[XmlArray("Buildings")]
	[XmlArrayItem("BuildingInfo")]
	public List<BuildingInfo> buildings = new List<BuildingInfo> ();
}

[Serializable]
public class BuildingInfo
{
	public Vector2 position;
	public int playerID;
	public int maxCapacity;
}