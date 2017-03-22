using UnityEngine;
using System.Collections;

public class ColorBarrier : MonoBehaviour {

	private PlayerController playerController;
	public GameObject stopper;

	public bool redBarrier, blueBarrier, yellowBarrier;

	void Awake () 
	{
		playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
        stopper.SetActive(true);
	}

	void OnTriggerStay (Collider collision)
	{
		if (collision.transform.tag == "Player")
		{
			if (redBarrier && playerController.abilitySetting.red) 
			{
				stopper.SetActive (false);
			} 
			else if (blueBarrier && playerController.abilitySetting.blue) 
			{
				stopper.SetActive (false);
			} 
			else if (yellowBarrier && playerController.abilitySetting.yellow) 
			{
				stopper.SetActive (false);
			} 
			else 
			{
				stopper.SetActive (true);
//				playerController.velocity.z -= 100;
			}
		}
	}

}
