using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioOnTouch : MonoBehaviour {

	public bool playOnlyOnce = true;
    public bool isTrigger = false;
	private bool done = false;

	void Start () 
	{
		AudioSource audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter (Collision other) 
	{
        if (other.transform.tag == "Player")
            TouchFunctions();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.transform.tag == "Player")
            TouchFunctions();
    }

    void TouchFunctions()
    {
        if (playOnlyOnce)
        {
            PlayAudio();
            playOnlyOnce = false;
            done = true;
        }
        else if (done)
        {
            return;
        }
        else
        {
            PlayAudio();
        }
    }

	void PlayAudio()
	{
		GetComponent<AudioSource> ().Play ();
	}
}
