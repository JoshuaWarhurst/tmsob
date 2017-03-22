using UnityEngine;
using System.Collections;

public class EXPPickup : MonoBehaviour {

	private float colorChangeSpeed = 5f;
	private float colorRepeatRate = 1f;
	private bool collected = false;

	private Collectibles collect;
    private COLLECTIBLE collectible;
	private Collider collider;
	private MeshRenderer renderer;
    private ParticleSystem partsys;
//	Animator anim;

	void Start ()
	{
        //		anim = GetComponent<Animator> ();
        partsys = GetComponent<ParticleSystem>();
        AudioSource audio = GetComponent<AudioSource>();
		collect = GameObject.Find ("GM").GetComponent<Collectibles> ();
		collider = GetComponent<SphereCollider> ();
		renderer = GetComponent<MeshRenderer> ();

		InvokeRepeating ("ChangeColor", colorChangeSpeed, colorRepeatRate);
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Player") 
		{
            collect.journeyCount += 1;
            this.GetComponent<AudioSource> ().Play ();
            partsys.Play();
            collect.collectible = COLLECTIBLE.JOURNEY_PICKUP;
            collect.CollectionPopup();
			collected = true;
//			anim.SetBool ("Collected", collected);
			collider.enabled = false;
			renderer.enabled = false;
//			Destroy (gameObject);
		}
	}

	void ChangeColor()
	{
		//pick a random color
		Color newColor = new Color (Random.value, Random.value, Random.value);
		//apply the color
		gameObject.GetComponent<Renderer>().material.color = newColor;
	}
}
