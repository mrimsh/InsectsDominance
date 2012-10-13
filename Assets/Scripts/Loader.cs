using System;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class Loader
{
	#region Singletone
	private static Loader _instance;
	
	public static Loader Instance {
		get {
			if (_instance == null) {
				_instance = new Loader ();
			}
			
			return _instance;
		}
			
	}

	private Loader ()
	{
	}
	#endregion
	
	private string storagePath = Path.Combine (Application.dataPath, "Resources/GameValues/");
	
	/// <summary>
	/// Sets the storage path, as a relative path to data files.
	/// </summary>
	/// <param name='storagePath'>
	/// Storage path.
	/// </param>
	public void SetStoragePath (string storagePath)
	{
		this.storagePath = storagePath;
	}
	
	/// <summary>
	/// Load the specified file of the type.
	/// </summary>
	/// <param name='fileName'> 
	/// Relative path from 'storagePath'.
	/// </param>
	/// <param name='type'>
	/// Class of object.
	/// </param>
	public object Load (string fileName, Type type)
	{
		object retObj = null;
		var serializer = new XmlSerializer (type);
		FileStream stream;
		
		bool bdf = File.Exists (storagePath + fileName);
		
		if (!File.Exists (storagePath + fileName)) {
			Save (fileName, Activator.CreateInstance (type), type);
		}
		
		try {
			stream = new FileStream (storagePath + fileName, FileMode.Open);
			using (stream) {
				retObj = serializer.Deserialize (stream);
			}
			stream.Close ();
		} catch (FileNotFoundException) {
		}
		
		return retObj;
	}
	
	/// <summary>
	/// Writes the serialized object into XML file..
	/// </summary>
	/// <param name='fileName'>
	/// XML file name, to store serialized object.
	/// </param>
	/// <param name='data'>
	/// Object for serialization.
	/// </param>
	/// <param name='type'>
	/// Type of object.
	/// </param>
	public void Save (string fileName, object data, Type type)
	{
		var serializer = new XmlSerializer (type);
		var stream = new FileStream (storagePath + fileName, FileMode.Create);
		serializer.Serialize (stream, data);
		stream.Close ();
	}
}
