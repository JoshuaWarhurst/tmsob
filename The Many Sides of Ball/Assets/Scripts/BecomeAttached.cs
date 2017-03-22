using UnityEngine;
using System.Collections;

public class BecomeAttached : MonoBehaviour {

	void  OnTriggerEnter (Collider other) { 
		other.transform.parent = gameObject.transform;
//		Debug.LogError ("Entering");
	}

	void OnTriggerExit (Collider other) {
		other.transform.parent = null;
//		Debug.LogError ("Exiting");
	}
}
