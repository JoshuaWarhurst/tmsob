using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour {

    public int targetFPS = 60;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = targetFPS;
    }

    void Update ()
    {
	if (targetFPS != Application.targetFrameRate)
            Application.targetFrameRate = targetFPS;
    }
}
