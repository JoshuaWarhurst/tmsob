using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnd: MonoBehaviour {

	public int nextLevel = 2;
	public float waitTimeBeforeLoading = 3f;

	private bool endScene = false;

	public void LoadScene(int nextLevel)
	{
		SceneManager.LoadScene (nextLevel);
	}

	IEnumerator Fade()
	{		
		float fadeTime = GameObject.Find ("GM").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
	}

	void Update () 
	{
		if (endScene) 
		{
			GameObject.Find ("GM").GetComponent<Fading> ().fadeDir = 1;
			waitTimeBeforeLoading -= Time.deltaTime;
			if (waitTimeBeforeLoading <= 0f)
			{
				LoadScene (nextLevel);
			}
		}

	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Player") 
		{
			endScene = true;
		}
	}
}
