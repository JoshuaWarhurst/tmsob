using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AddVoiceOverDeprecated : MonoBehaviour {

	public SUBTITLE_TYPE subtitleText;
//	public SUBTITLE_TYPE subtitleText2;
//	public SUBTITLE_TYPE subtitleText3;
//	public int subtitleCount = 1;
	public bool playOnExit = false;
	public float waitToPlay = 0f;
//	public float waitForSeconds;
	private bool waiting = false;
	private bool subtitlePlayed = false;

	private VoiceOverMaster vo;

	void Awake () 
	{
		vo = GameObject.Find ("GM").GetComponent<VoiceOverMaster> ();
		AudioSource audio = GetComponent<AudioSource>();
	}

    void Update()
	{
		if (waiting) 
		{
			waitToPlay -= Time.deltaTime;
			if (waitToPlay <= 0 && subtitlePlayed == false) 
			{
				PlaySubtitle ();
				waiting = false;
			}
		}
	}

	//used with any kind of collider when the goal is to play the subtitle when the player hits it
	void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Player" && subtitlePlayed == false && playOnExit == false) 
		{
			if (waitToPlay > 0) 
			{
				waiting = true;
			}
			else
				PlaySubtitle ();
		}
	}
		
	//used in case of triggered sphere colliders, usually on exiting one from the start of the level 
	void OnTriggerExit (Collider collision)
	{
		if (collision.transform.tag == "Player" && subtitlePlayed == false && playOnExit == true) 
		{
			if (waitToPlay > 0) 
			{
				waiting = true;
			}
			else
				PlaySubtitle ();
		}

		//different from above OnTriggerExit
		//this OnTriggerExit makes the subtitle cancel if you move from the spot
		//used with below OnTriggerStay
		else if (collision.transform.tag == "Player" && subtitlePlayed == false && playOnExit == false) 
		{
			subtitlePlayed = true;
		}
	}

	//used for voice overs that require you to stay in one spot
	void OnTriggerStay (Collider collision)
	{
		if (collision.transform.tag == "Player" && subtitlePlayed == false && playOnExit == false) 
		{
			if (waitToPlay > 0) 
			{
				waiting = true;
			}
			else
				PlaySubtitle ();
		}
	}


	public void PlaySubtitle()
	{
		if (GetComponent<AudioSource>() != null) 
		{
			if (vo.currentAudio != null) 
			{
				vo.currentAudio.Stop ();
			}
			GetComponent<AudioSource> ().Play ();
			vo.currentAudio = GetComponent<AudioSource> ();
		}
//		vo.subtitleType = subtitleText; //sets the voice over subtitle number to the number on this object
//		vo.ChooseSubtitle ();
        vo.PlaySubtitle ();
		vo.playVO = true;
		subtitlePlayed = true;
	}
}
