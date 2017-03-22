using UnityEngine;
using System.Collections;

public class IncreaseStat : MonoBehaviour {

	public float accelUP;
    public float startForwardVelUP;
	public float maxForwardVelUP;
	public float jumpUP;

	PlayerController player;
	private MeshRenderer renderer;

	void Start ()
	{
		player = GameObject.Find ("Player").GetComponent<PlayerController> ();
		renderer = GetComponent<MeshRenderer> ();
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Player") 
		{
			player.moveSetting.accel += accelUP;
            player.moveSetting.startForwardVel += startForwardVelUP;
			player.moveSetting.maxForwardVel += maxForwardVelUP;
			player.moveSetting.jumpVel += jumpUP;
			renderer.enabled = false;
		}
	}
		
}
