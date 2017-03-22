using UnityEngine;
using System.Collections;

public class LevelStart : MonoBehaviour {

	public string levelName;

	private float posX = 200;
	private float posY = 100;
	private float labelWidth = 500;
	private float labelHeight = 300;

	private GUIStyle style = new GUIStyle();

	void OnGUI()
	{
//		style.fontSize = 20;
//		GUILayout.Label (new Rect (posX, posY, labelWidth, labelHeight), levelName, style);
	}

	void Update () {
	
	}
}
