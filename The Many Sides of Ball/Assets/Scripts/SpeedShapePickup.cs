using UnityEngine;
using System.Collections;

public class SpeedShapePickup : MonoBehaviour {

	public float countDown;
	private bool timeUp = false;

	private Collectibles collect;
	private Collider collider;
	private MeshRenderer renderer;

	void Start ()
	{
		AudioSource audio = GetComponent<AudioSource>();
		collect = GameObject.Find ("GM").GetComponent<Collectibles> ();
		collider = GetComponent<SphereCollider> ();
		renderer = GetComponent<MeshRenderer> ();

		InvokeRepeating ("Countdown", 1, 1);
		timeUp = false;
	}

	void Update()
	{
		if (countDown <= 0f)
			timeUp = true;
		if (timeUp == true)
			BecomeTransparent ();	
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Player" && timeUp == false) 
		{
            collect.speedCount += 1;
            collect.collectible = COLLECTIBLE.SPEED_PICKUP;
            collect.CollectionPopup();
            //			Destroy (gameObject);
            this.GetComponent<AudioSource> ().Play ();
			GetComponentInChildren<ParticleSystem> ().Stop ();
			collider.enabled = false;
			renderer.enabled = false;
		}
	}

	void Countdown()
	{
		countDown -= Time.deltaTime;
	}

	void BecomeTransparent()
	{
		this.GetComponent<MeshRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
		collider.enabled = false;
	}
}
