using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFogColor : MonoBehaviour {

    public Color color = Color.grey;

	void Start ()
    {
        RenderSettings.fogColor = color;
    }
}
