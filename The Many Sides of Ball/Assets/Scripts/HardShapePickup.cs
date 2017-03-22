using UnityEngine;
using System.Collections;

public class HardShapePickup : MonoBehaviour {

	private CollectiblesV2 collect;
	private Collider collider;
	private MeshRenderer renderer;
    private ParticleSystem partsys;

	void Start ()
	{
		AudioSource audio = GetComponent<AudioSource>();
		collect = GameObject.Find ("GM").GetComponent<CollectiblesV2> ();
		collider = GetComponent<SphereCollider> ();
		renderer = GetComponent<MeshRenderer> ();
        partsys = GetComponent<ParticleSystem>();
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Player") 
		{
            //			Destroy (gameObject);
            collect.hardCount += 1;
            collect.collectible = COLLECTIBLE.HARD_PICKUP;
            //collect.CollectionPopup();
            partsys.Play();
			this.GetComponent<AudioSource> ().Play ();
			collider.enabled = false;
			renderer.enabled = false;
		}
	}
}
