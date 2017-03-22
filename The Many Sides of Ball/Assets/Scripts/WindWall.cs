using UnityEngine;
using System.Collections;

public class WindWall : MonoBehaviour {

	public float windSpeed = 10f;

	public enum WIND_DIRECTION
	{
		NORTH,
		SOUTH,
		WEST,
		EAST,
		UP,
		DOWN,
	}
	public WIND_DIRECTION windDirection = WIND_DIRECTION.NORTH;


	void Start ()
	{
		AudioSource audio = GetComponent<AudioSource>();
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.tag == "Player") 
		{
			GetComponent<AudioSource> ().Play ();
		}
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.tag == "Player") 
		{
			switch (windDirection) 
			{
			case WIND_DIRECTION.NORTH:
				collider.GetComponent<Rigidbody> ().AddForce (Vector3.forward * windSpeed);
				break;
			case WIND_DIRECTION.SOUTH:
				collider.GetComponent<Rigidbody> ().AddForce (Vector3.back * windSpeed);
				break;
			case WIND_DIRECTION.WEST:
				collider.GetComponent<Rigidbody> ().AddForce (Vector3.left * windSpeed);
				break;
			case WIND_DIRECTION.EAST:
				collider.GetComponent<Rigidbody> ().AddForce (Vector3.right * windSpeed);
				break;
			case WIND_DIRECTION.UP:
				collider.GetComponent<Rigidbody> ().AddForce (Vector3.up * windSpeed);
				break;
			case WIND_DIRECTION.DOWN:
				collider.GetComponent<Rigidbody> ().AddForce (Vector3.down * windSpeed);
				break;
			}
		}
	}

	void OnTriggerExit (Collider collider)
	{
		if (collider.tag == "Player") 
		{
			GetComponent<AudioSource> ().Stop ();
		}
	}

}
