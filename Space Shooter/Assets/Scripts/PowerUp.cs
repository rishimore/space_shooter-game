using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	
	void Start () {
   gameObject.transform.GetChild(0).gameObject.SetActive(false);
  }

	void OnTriggerEnter(Collider other)
	{
	  if(other.tag == "pu1")
	  {
		Debug.Log("activating pu");
		
		gameObject.GetComponent<TripleShot>().puEnabled = true;
		StartCoroutine(DisableTripleShot());
		Debug.Log("pu Over");
		Destroy(other.gameObject);
	  }

   
	 	if(other.tag == "pu2")
	  {
		Debug.Log("activating pu");
		
		gameObject.transform.GetChild(0).gameObject.SetActive(true);
		gameObject.GetComponent<MultiShot>().pu1Enabled = true;
		StartCoroutine(DisableShield());
		Debug.Log("pu Over");
		Destroy(other.gameObject);
	  } 
  
	/* 	if(other.tag == "pu2")
	  {
		Debug.Log("activating pu");
		
		gameObject.GetComponent<MultiShot>().pu1Enabled = true;
		StartCoroutine(DisableMultiShot());
		Debug.Log("pu Over");
		Destroy(other.gameObject);
	  }*/	
	}

	IEnumerator DisableTripleShot()
	{
		yield return new WaitForSeconds(7);
		gameObject.GetComponent<TripleShot>().puEnabled = false;
		Debug.Log("pu disabled");
	}


/* 	IEnumerator DisableMultiShot()
	{
		yield return new WaitForSeconds(7);
		gameObject.GetComponent<MultiShot>().pu1Enabled = false;
		Debug.Log("pu disabled");
	}
	*/

	IEnumerator DisableShield()
	{
		yield return new WaitForSeconds(7);
		gameObject.transform.GetChild(0).gameObject.SetActive(false);
		gameObject.GetComponent<MultiShot>().pu1Enabled = false;
		Debug.Log("pu disabled");
	}
	
}
