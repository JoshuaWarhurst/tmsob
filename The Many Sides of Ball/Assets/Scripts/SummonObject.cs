using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SummonObject : MonoBehaviour {

	public GameObject summonedObject;

	public CanvasGroup myCG;

	private bool flash = false;

	void Update ()
	{
		if (flash)
		{
			myCG.alpha = myCG.alpha - Time.deltaTime;
			if (myCG.alpha <= 0)
			{
				myCG.alpha = 0;
				flash = false;
			}
		}
	}

	void OnTriggerEnter (Collider collider)
	{
		if (collider.transform.tag == "Player")
		{
			flash = true;
			myCG.alpha = 1;
			summonedObject.SetActive (true);
			this.GetComponent<Collider>().enabled = false;
		}
	}
}
