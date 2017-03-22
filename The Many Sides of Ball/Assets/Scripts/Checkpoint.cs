using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public GameObject restart;

	void OnTriggerEnter (Collider collision)
	{
		if (collision.transform.tag == "Player") 
		{
			restart.transform.position = this.transform.position;
		}
	}
}
