using UnityEngine;
using System.Collections;

public class RemoveSphereCollider : MonoBehaviour {

	public bool removeOnExit = true;

	private Collider collider;

	void Start()
	{
		collider = GetComponent<SphereCollider>();
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Player" && removeOnExit == false) 
		{
			collider.enabled = false;
		}
	}

	void OnTriggerExit (Collider collision)
	{
		if (collision.transform.tag == "Player" && removeOnExit == true) 
		{
			collider.enabled = false;
		}
	}

}
