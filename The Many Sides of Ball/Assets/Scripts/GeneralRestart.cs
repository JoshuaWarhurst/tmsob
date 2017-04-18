using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GeneralRestart : MonoBehaviour {

	public Transform destination;
	public Transform player;

	private bool waiting = false;
	private float waitTime;

	void Update()
	{
        if (Input.GetKeyDown("k"))
        {
            RestartCommand();
        }
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

	public void RestartCommand()
	{
			GameObject.Find ("GM").GetComponent<Fading> ().fadeDir = 1;
			waiting = true;
			waitTime = 2f;
	}

	void Restart()
	{
		player.transform.position = destination.position;
	}
}
