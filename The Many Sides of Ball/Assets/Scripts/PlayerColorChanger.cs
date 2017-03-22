using UnityEngine;
using System.Collections;

public class PlayerColorChanger : MonoBehaviour {

	public enum TO_COLOR
	{
		RED,
		BLUE,
		YELLOW,
		REDBLUE,
		BLUEYELLOW,
		YELLOWRED,
	}

	public TO_COLOR toColor = TO_COLOR.RED;

	public Color lerpedColor;

	private PlayerController playerController;

	void Start () 
	{
		playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}

	void Update ()
	{
		ColorLerp ();
	}

	void OnTriggerStay (Collider collision)
	{
		if (collision.transform.tag == "Player")
		{
			switch (toColor) 
			{
			case TO_COLOR.RED:
				playerController.abilitySetting.red = true;
				playerController.abilitySetting.blue = false;
				playerController.abilitySetting.yellow = false;
				playerController.ChangeColor ();
				break;
			case TO_COLOR.BLUE:
				playerController.abilitySetting.red = false;
				playerController.abilitySetting.blue = true;
				playerController.abilitySetting.yellow = false;
				playerController.ChangeColor ();
				break;
			case TO_COLOR.YELLOW:
				playerController.abilitySetting.red = false;
				playerController.abilitySetting.blue = false;
				playerController.abilitySetting.yellow = true;
				playerController.ChangeColor ();
				break;
			case TO_COLOR.REDBLUE:
				if (playerController.abilitySetting.red == true) {
					playerController.abilitySetting.red = false;
					playerController.abilitySetting.blue = true;
					playerController.ChangeColor ();
				} else if (playerController.abilitySetting.blue == true) {
					playerController.abilitySetting.blue = false;
					playerController.abilitySetting.red = true;
					playerController.ChangeColor ();
				} else {
					return;
				}
				break;
			case TO_COLOR.BLUEYELLOW:
				if (playerController.abilitySetting.yellow == true) {
					playerController.abilitySetting.yellow = false;
					playerController.abilitySetting.blue = true;
					playerController.ChangeColor ();
				} else if (playerController.abilitySetting.blue == true) {
					playerController.abilitySetting.blue = false;
					playerController.abilitySetting.yellow = true;
					playerController.ChangeColor ();
				} else {
					return;
				}
				break;
			case TO_COLOR.YELLOWRED:
				if (playerController.abilitySetting.red == true) {
					playerController.abilitySetting.red = false;
					playerController.abilitySetting.yellow = true;
					playerController.ChangeColor ();
				} else if (playerController.abilitySetting.yellow == true) {
					playerController.abilitySetting.yellow = false;
					playerController.abilitySetting.red = true;
					playerController.ChangeColor ();
				} else {
					return;
				}
				break;
			}

/*			if (collision.transform.tag == "Player") {
			if (redBlue == true) {
				if (playerController.abilitySetting.red == true) {
					playerController.abilitySetting.red = false;
					playerController.abilitySetting.blue = true;
					playerController.ChangeColor ();
				} else if (playerController.abilitySetting.blue == true) {
					playerController.abilitySetting.blue = false;
					playerController.abilitySetting.red = true;
					playerController.ChangeColor ();
				} else
					return;
			}

			if (blueYellow == true) {
				if (playerController.abilitySetting.yellow == true) {
					playerController.abilitySetting.yellow = false;
					playerController.abilitySetting.blue = true;
					playerController.ChangeColor ();
				} else if (playerController.abilitySetting.blue == true) {
					playerController.abilitySetting.blue = false;
					playerController.abilitySetting.yellow = true;
					playerController.ChangeColor ();
				} else
					return;
			}

			if (redYellow == true) {
				if (playerController.abilitySetting.red == true) {
					playerController.abilitySetting.red = false;
					playerController.abilitySetting.yellow = true;
					playerController.ChangeColor ();
				} else if (playerController.abilitySetting.yellow == true) {
					playerController.abilitySetting.yellow = false;
					playerController.abilitySetting.red = true;
					playerController.ChangeColor ();
				} else
					return;
			}
*/
		}
	}

	void ColorLerp ()
	{
		switch (toColor) 
		{
		case TO_COLOR.RED:
			lerpedColor = Color.Lerp (Color.red, Color.red, Mathf.PingPong (Time.time, 3));
			break;
		case TO_COLOR.BLUE:
			lerpedColor = Color.Lerp (Color.blue, Color.blue, Mathf.PingPong (Time.time, 3));
			break;
		case TO_COLOR.YELLOW:
			lerpedColor = Color.Lerp (Color.yellow, Color.yellow, Mathf.PingPong (Time.time, 3));
			break;
		case TO_COLOR.REDBLUE:
			lerpedColor = Color.Lerp (Color.red, Color.blue, Mathf.PingPong (Time.time, 3));
			break;
		case TO_COLOR.BLUEYELLOW:
			lerpedColor = Color.Lerp (Color.blue, Color.yellow, Mathf.PingPong (Time.time, 3));
			break;
		case TO_COLOR.YELLOWRED:
			lerpedColor = Color.Lerp (Color.yellow, Color.red, Mathf.PingPong (Time.time, 3));
			break;
		}
		gameObject.GetComponent<Renderer>().material.color = lerpedColor;
	}

}