using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
   public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour {

 	public float speed;
	public Boundary boundary;
	public float tilt;
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private Rigidbody prb;
    private float nextFire; 

   /*  void Awake()
	{
	   speed = 0;
	   StartCoroutine(PlayerTimer());	
	} */

	private void Start() {
		prb = GetComponent<Rigidbody>();
	}

    void Update()
	{
       if (Input.GetButton("Fire1") && Time.time > nextFire)
	   {
		   nextFire = Time.time + fireRate;
		   GameObject obj = ObjectPoolerScr.current.GetPoolObject();
			obj.transform.position = shotSpawn.position;
			obj.transform.rotation = shotSpawn.rotation;
			obj.SetActive(true);   
	   }     
	}

	void FixedUpdate() {
      float moveHorizontal = Input.GetAxis("Horizontal");
	   float moveVertical = Input.GetAxis("Vertical");
	    
	   Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
	   prb.velocity = movement * speed;

		prb.position = new Vector3
	   (
		  Mathf.Clamp (prb.position.x, boundary.xMin, boundary.xMax),
		  0.0f,
      	Mathf.Clamp (prb.position.z, boundary.zMin, boundary.zMax)    
	   );
	   prb.rotation = Quaternion.Euler(0.0f, 0.0f, prb.velocity.x * -tilt);
	}

  /*   IEnumerator PlayerTimer()
	{
		yield return new WaitForSeconds(4);
		speed = 15;
	}
	*/
}

