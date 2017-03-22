using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VoiceOverMaster: MonoBehaviour {

    [HideInInspector]
    public string key;
	[HideInInspector]
	public bool subtitlesActive = true;

	public GameObject subtitleTextUI;
	public Text subtitleText;

	[HideInInspector]
	private string script;
	[HideInInspector]
	public float subtitleTime;
	[HideInInspector]
	public bool playVO = false;
	[HideInInspector]
	public AudioSource currentAudio;
    private VolumeSettings vs;

    private void Start()
    {
        Text subtitleText = GetComponent<Text>();
        vs = FindObjectOfType<VolumeSettings>();
    } 

    void Update () 
	{
		if (playVO == true) 
		{
			subtitleTime -= Time.deltaTime;
		}
		if (subtitleTime <= 0)
			EndSubtitle ();
	}

	//called in AddVoiceOver script
	public void PlaySubtitle()
	{
        subtitleText.text = LocalizationManager.instance.GetLocalizedValue(key);
        vs.ChangeBackgroundVolume(-2.5f);
		subtitleTextUI.SetActive (true);
	}

	void EndSubtitle()
	{
		playVO = false;
        vs.ChangeBackgroundVolume(0f);
        subtitleTextUI.SetActive (false);
    }
	
	
}