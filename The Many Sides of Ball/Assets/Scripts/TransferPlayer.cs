using UnityEngine;
using System.Collections;

public class TransferPlayer : MonoBehaviour {

	public Transform destination;
	public Transform player;

	private bool waiting = false;
	private float waitTime;
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") 
		{
			GameObject.Find ("GM").GetComponent<Fading> ().fadeDir = 1;
			waiting = true;
			waitTime = 2f;
//			Restart ();
//			GameObject.Find ("GM").GetComponent<Fading> ().fadeDir = -1;
		}
	}

	void Update()
	{
		if (waiting) 
		{
			waitTime -= Time.deltaTime;	
			if (waitTime <= 1) 
			{
				Restart ();
			}
			if (waitTime <= 0) 
			{
				GameObject.Find ("GM").GetComponent<Fading> ().fadeDir = -1;
				waiting = false;
			}
		}
	}

	void Restart()
	{
		player.transform.position = destination.position;
	}
}
