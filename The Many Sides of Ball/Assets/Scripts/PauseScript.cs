using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class PauseScript : MonoBehaviour {

	public GameObject pauseScreenUI;

	private CollectiblesV2 collect;

//	AudioSource audio;

	void Start ()
	{
		collect = GameObject.Find ("GM").GetComponent<CollectiblesV2> ();
//		audio = GetComponent<AudioSource> ();
	}

	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			TogglePauseMenu();
			if (pauseScreenUI.activeSelf) 
			{
				//stop time
				Time.timeScale = 0;
//				audio.pitch = 0.95f;
				collect.SetPauseMenuText ();
			} 
			else 
			{
				//time flows normally while out of pause menu
				Time.timeScale = 1;
//				audio.pitch = 1f;
			}
		}
	}

	void TogglePauseMenu()
	{
		pauseScreenUI.SetActive (!pauseScreenUI.activeSelf);
	}
}
