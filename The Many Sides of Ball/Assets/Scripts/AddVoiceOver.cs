using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AddVoiceOver : MonoBehaviour {

    public string key;
    public float subtitleTime;

	public float waitToPlay = 0f;

    private LocalizationManager lm;
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
        vo.key = key;
        vo.subtitleTime = subtitleTime;
        waitToPlay = vo.subtitleTime;
        vo.PlaySubtitle ();
		vo.playVO = true;
    }
}
