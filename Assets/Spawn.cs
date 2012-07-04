using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

public GameObject prefab;

public void Update(){
		float prefabX = prefab.transform.position.x;
		float prefabZ = prefab.transform.position.z;

		for(int i=0; i<20;){
			float cloneX = Random.Range(prefabX-100.0f,prefabX+100.0f);
			float cloneZ = Random.Range(prefabZ-100.0f,prefabZ+100.0f);

			float distance = Mathf.Sqrt(Mathf.Pow(cloneX-prefabX,2)+Mathf.Pow(cloneZ-prefabZ,2));

			if(distance>=50.0){
			Instantiate(prefab, new Vector3(cloneX, 0, cloneZ), Quaternion.identity);
				i++;
				}
			}
		}
	}