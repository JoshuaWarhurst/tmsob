using UnityEngine;
using System.Collections;

public class PickUpAndThrow : MonoBehaviour {

	public Transform HoldPosition; //This is the point where the picked up objects go
	public Transform BigHoldPosition; //This is the point where the big picked up objects go
	public float ThrowForce = 10f; //How strong the throw is. This assumes the picked object has a rigidbody component attached

	private bool carrying;
	private Transform _pickedObject;

	//pickup
	void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Pickup") 
		{
			if (carrying == false) 
			{
				//caches the picked object
				_pickedObject = collision.transform;

				_pickedObject.GetComponent<Rigidbody> ().useGravity = false;
				_pickedObject.GetComponent<Rigidbody> ().isKinematic = true;

				//this will snap the picked object to the "hands" of the player
				_pickedObject.position = HoldPosition.position;

				//this will set the HoldPosition as the parent of the pickup so it will stay there
				_pickedObject.parent = HoldPosition;

				carrying = true;

				ThrowForce = 10;
			}
		}
		if (collision.transform.tag == "BigPickup") 
		{
			if (carrying == false) 
			{
				//caches the picked object
				_pickedObject = collision.transform;

				_pickedObject.GetComponent<Rigidbody> ().useGravity = false;
				_pickedObject.GetComponent<Rigidbody> ().isKinematic = true;

				//this will snap the picked object to the "hands" of the player
				_pickedObject.position = BigHoldPosition.position;

				//this will set the BigHoldPosition as the parent of the pickup so it will stay there
				_pickedObject.parent = BigHoldPosition;

				carrying = true;

				ThrowForce = 5;
			}
		}
	}

	void PutDown()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			if (_pickedObject != null)
			{
				//resets the pickup's parent to null so it won't keep following the player
				_pickedObject.parent = null;

				_pickedObject.GetComponent<Rigidbody> ().useGravity = true;
				_pickedObject.GetComponent<Rigidbody> ().isKinematic = false;

				//applies force to the rigidbody to create a throw
				_pickedObject.GetComponent<Rigidbody>().AddForce(transform.forward * ThrowForce, ForceMode.Impulse);

				//resets the _pickedObject 
				_pickedObject = null;

				carrying = false;
			}
		}
	}

	void Update()
	{
		PutDown ();
	}
}
