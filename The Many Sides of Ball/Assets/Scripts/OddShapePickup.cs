using UnityEngine;
using System.Collections;

public class OddShapePickup : MonoBehaviour {

	private Collectibles collect;
	private Collider collider;
	private MeshRenderer renderer;

	void Start ()
	{
		AudioSource audio = GetComponent<AudioSource>();
		collect = GameObject.Find ("GM").GetComponent<Collectibles> ();
		collider = GetComponent<SphereCollider> ();
		renderer = GetComponent<MeshRenderer> ();
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Player") 
		{
            collect.oddCount += 1;
            collect.collectible = COLLECTIBLE.ODD_PICKUP;
            collect.CollectionPopup();
            //			Destroy (gameObject);
            this.GetComponent<AudioSource> ().Play ();
			collider.enabled = false;
			renderer.enabled = false;
		}
	}
}
