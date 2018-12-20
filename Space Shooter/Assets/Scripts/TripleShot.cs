using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShot : MonoBehaviour {

    public GameObject shot1;
	public GameObject shot2;
	public bool puEnabled = false;

    public Transform shotSpawn1;
	public Transform shotSpawn2;

    public float fireRate1;

    private float nextFire1; 
	void Update()
	{
       if (Input.GetButton("Fire1") && Time.time > nextFire1 && puEnabled)
	   {
		   nextFire1 = Time.time + fireRate1;

		   Instantiate(shot1, shotSpawn1.position, shotSpawn1.rotation);
		   Instantiate(shot2, shotSpawn2.position, shotSpawn2.rotation);
		      
	   }     
	}
}
