using UnityEngine;
using System.Collections;

public class AutoMove : MonoBehaviour {

	public float moveX = 0f;
	public float moveY = 0f;
	public float moveZ = 0f;

	public bool autoDisappear = false;
	public float disappearTime = 20f;
	private float textDisappear = 0f;

	void Start()
	{
		textDisappear = disappearTime;
	}
		
	void Update () 
	{
		this.transform.Translate (Vector3.right * moveX * Time.deltaTime);
		this.transform.Translate (Vector3.up * moveY * Time.deltaTime);
		this.transform.Translate (Vector3.forward * moveZ * Time.deltaTime);

		if (autoDisappear) 
		{
			disappearTime -= Time.deltaTime;
			moveY += Time.deltaTime;
			if (disappearTime <= 0) 
			{
				Destroy (gameObject);
			}
			if (GetComponent<TextMesh> ().fontSize > 0) 
			{
				FontShrink ();
			}
		}
	}

	IEnumerator FontShrink ()
	{
		yield return new WaitForSeconds(1);
		GetComponent<TextMesh> ().fontSize -= 1;
	}
}
