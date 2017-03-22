using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	[HideInInspector]
	public int fadeDir = -1;

	void OnGUI()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); //draw texture to fit the entire screen area
	}

	public float BeginFade (int direction)
	{
		fadeDir = direction;
		return (fadeSpeed);		//return the fadeSpeed variable so it's easy to time the ScreenManager.LoadScene();
	}

	void OnSceneWasLoaded()
	{
		BeginFade (-1);
	}

}
