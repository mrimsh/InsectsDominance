using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

public GameObject prefab;
	
	void spawn(){
		float prefabX = prefab.transform.position.x;
		float prefabZ = prefab.transform.position.z;

		for(int i=0; i<10;){
			float cloneX = Random.Range(prefabX-100.0f,prefabX+100.0f);
			float cloneZ = Random.Range(prefabZ-100.0f,prefabZ+100.0f);

			Vector3 distance = new Vector3(cloneX-prefabX,0,cloneZ-prefabZ);

			if(distance.magnitude>=20.0){
				Instantiate(prefab, new Vector3(cloneX, 0, cloneZ), Quaternion.identity);
				i++;
				}
			}
		}
	public void Start(){
		spawn();
		}
	}