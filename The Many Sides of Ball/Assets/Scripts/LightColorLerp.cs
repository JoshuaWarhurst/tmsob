using UnityEngine;
using System.Collections;

public class LightColorLerp : MonoBehaviour {

	public Light light;

    public Color color0;
    public Color color1;

	public Color lerpedColor;

    public bool lerpTo = false;
    private float lerpIncrement = 0f;
    public float lerpToTime = 1f;

	void Start ()
	{
		light = GetComponent<Light> ();
        color0 = light.color;
	}

	void Update () 
	{
        if (lerpTo)
        {
            lerpIncrement += (1 / lerpToTime);
            lerpedColor = Color.Lerp(color0, color1, lerpIncrement);
        }
        else
        {
            lerpedColor = Color.Lerp(Color.white, Color.yellow, Mathf.PingPong(Time.deltaTime, 3));
        }
        light.color = lerpedColor;
	}
}
