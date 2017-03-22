using UnityEngine;
using System.Collections;

public class DestroyIncomingObjects : MonoBehaviour {

	public int destroyCount1;
	public int destroyCount2;
	public int destroyCount3;

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Pickup") 
		{
			Destroy (other.gameObject);
		}
		if (other.transform.tag == "Pickup1") 
		{
			destroyCount1 += 1;
			Destroy (other.gameObject);
		}
		if (other.transform.tag == "Pickup2") 
		{
			destroyCount2 += 1;
			Destroy (other.gameObject);
		}
		if (other.transform.tag == "Pickup3") 
		{
			destroyCount3 += 1;
			Destroy (other.gameObject);
		}
		if (other.transform.tag == "NPC") 
		{
			Destroy (other.gameObject);
		}
		if (other.transform.tag == "Player") 
		{
			return;
		}
	}
}
