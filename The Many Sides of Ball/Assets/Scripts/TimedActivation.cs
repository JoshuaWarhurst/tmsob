using UnityEngine;
using System.Collections;

public class TimedActivation : MonoBehaviour {

	public float waitToStart = 1f; 
	public GameObject objectToTurnOn;

	void Start()
	{
		objectToTurnOn.SetActive (false);
	}

	void Update () 
	{
		waitToStart -= Time.deltaTime;
		if (waitToStart <= 0f) 
		{
			Activate ();
		}
	}

	void Activate()
	{
		objectToTurnOn.SetActive (true);
	}
}
