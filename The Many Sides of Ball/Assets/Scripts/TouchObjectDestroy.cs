using UnityEngine;
using System.Collections;

public class TouchObjectDestroy : MonoBehaviour 
{
	//Destroys the object if something touches it

	public bool destroyIfPlayer;
	public bool destroyIfPickup;
	public bool destroyIfBigPickup;

	void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Player" && destroyIfPlayer == true) 
		{
			Destroy (gameObject);
		}
		if (collision.transform.tag == "Pickup" && destroyIfPickup == true) 
		{
			Destroy (gameObject);
		}
		if (collision.transform.tag == "BigPickup" && destroyIfBigPickup == true) 
		{
			Destroy (gameObject);
		}
	}

}
