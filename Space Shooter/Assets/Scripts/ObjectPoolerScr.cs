using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolerScr : MonoBehaviour {

	public static ObjectPoolerScr current;
	public GameObject pooledObj;
	public int pooledAmt;
	public bool willGrow;

	public List<GameObject> pooledObject;

    private void Awake()
	{
		current = this;
	}

	// Use this for initialization
	void Start () {
		pooledObject = new List<GameObject>();
		for (int i=0; i < pooledAmt; i++)
		{
			GameObject obj = (GameObject)Instantiate(pooledObj);
		    obj.SetActive(false);
			pooledObject.Add(obj);			
		}
    }

	public GameObject GetPoolObject()
	{
		for (int i=0; i < pooledObject.Count; i++)
		{
			if(!pooledObject[i].activeInHierarchy) return pooledObject[i];
		}

		if(willGrow)
		{
			GameObject obj = (GameObject)Instantiate(pooledObj);
			pooledObject.Add(obj);
			return obj;
		}
		return null;
	}

}
