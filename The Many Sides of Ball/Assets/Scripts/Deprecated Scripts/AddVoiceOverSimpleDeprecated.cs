using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class AddVoiceOverSimpleDeprecated : MonoBehaviour {

	public SUBTITLE_TYPE subtitleText;
	public float waitToPlay = 0f;

	private VoiceOverMaster vo;

	void Awake () 
	{
		vo = GameObject.Find ("GM").GetComponent<VoiceOverMaster> ();
		AudioSource audio = GetComponent<AudioSource>();
	}

    void Start()
    {
        PlaySubtitle();
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
//        vo.ChooseSubtitle ();
        waitToPlay = vo.subtitleTime;
        vo.PlaySubtitle ();
		vo.playVO = true;
	}
}
