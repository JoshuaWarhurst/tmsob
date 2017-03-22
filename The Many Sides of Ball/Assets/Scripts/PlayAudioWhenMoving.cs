using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioWhenMoving : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		AudioSource audio = GetComponent<AudioSource> ();
		transform.hasChanged = false;
	}

	void Update () 
	{
		if (transform.hasChanged) 
		{
			GetComponent<AudioSource> ().Play ();
			transform.hasChanged = false;
		} 
		else 
		{
			GetComponent<AudioSource> ().Stop ();
		}
	}
}
