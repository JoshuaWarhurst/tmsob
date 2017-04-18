using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class PauseScript : MonoBehaviour {

	public GameObject pauseScreenUI;

	private CollectiblesV2 collect;

    public string PAUSE_MENU_BUTTON = "Cancel";

    void Start ()
	{
		collect = GameObject.Find ("GM").GetComponent<CollectiblesV2> ();
    }

	void Update () 
	{
		if (Input.GetButtonDown(PAUSE_MENU_BUTTON))
		{
			TogglePauseMenu();
		}
        if (pauseScreenUI.activeSelf)
        {
            //stop time
            Time.timeScale = 0;
            MusicMaster.musicMaster.backgroundMusic.volume -= 0.3f;
            collect.SetPauseMenuText();
        }
        else
        {
            //time flows normally while out of pause menu
            Time.timeScale = 1;
            MusicMaster.musicMaster.backgroundMusic.volume += 0.3f;
        }
    }

	public void TogglePauseMenu()
	{
		pauseScreenUI.SetActive (!pauseScreenUI.activeSelf);
	}
}
