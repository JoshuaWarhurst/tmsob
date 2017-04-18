using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickRestart : MonoBehaviour {

    public void RestartFromLastCheckpoint()
    {
        GameObject.Find("GM").GetComponent<GeneralRestart>().RestartCommand();
        GameObject.Find("GM").GetComponent<PauseScript>().TogglePauseMenu();
    }
}
