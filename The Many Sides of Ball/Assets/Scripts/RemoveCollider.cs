using UnityEngine;
using System.Collections;

public class RemoveCollider : MonoBehaviour {

	private Collider collider;

	void Start()
	{
		collider = this.GetComponent<Collider>();
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Player") 
		{
			collider.enabled = false;
		}
	}
	void OnCollisionStay (Collision collision)
	{
		if (collision.transform.tag == "Player") 
		{
			collider.enabled = false;
		}
	}
	void OnCollisionExit (Collision collision)
	{
		if (collision.transform.tag == "Player") 
		{
			collider.enabled = false;
		}
	}

	void OnColliderEnter (Collider collision)
	{
		if (collision.transform.tag == "Player") 
		{
			collider.enabled = false;
		}
	}

	void OnColliderStay (Collider collision)
	{
		if (collision.transform.tag == "Player") 
		{
			collider.enabled = false;
		}
	}

	void OnColliderExit (Collider collision)
	{
		if (collision.transform.tag == "Player") 
		{
			collider.enabled = false;
		}
	}
}
