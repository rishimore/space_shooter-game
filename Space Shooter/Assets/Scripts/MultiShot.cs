using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShot : MonoBehaviour {

	public GameObject shot1;
	public GameObject shot2;
	public GameObject shot3;
	public GameObject shot4;
	public GameObject shot5;

	public bool pu1Enabled = false;

    public Transform shotSpawn1;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public Transform shotSpawn4;
	public Transform shotSpawn5;

    public float fireRate1;

    private float nextFire1;

	
	
	
	void Update()
	{
       if (Input.GetButton("Fire1") && Time.time > nextFire1 && pu1Enabled)
	   {
		   nextFire1 = Time.time + fireRate1;

		   Instantiate(shot1, shotSpawn1.position, shotSpawn1.rotation);
		   Instantiate(shot2, shotSpawn2.position, shotSpawn2.rotation);
		   Instantiate(shot3, shotSpawn3.position, shotSpawn3.rotation);
		   Instantiate(shot4, shotSpawn4.position, shotSpawn4.rotation);
		   Instantiate(shot5, shotSpawn5.position, shotSpawn5.rotation);
		      
	   }     
	}
}
