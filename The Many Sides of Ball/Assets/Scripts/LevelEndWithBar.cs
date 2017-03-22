using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEndWithBar : MonoBehaviour {

//	public CanvasGroup myBlackCG;
	public int nextLevel = 2;

	private float waitTimeBeforeLoading = 3f;

	private bool endScene = false;
	public Slider loadingBar;
	public GameObject loadingImage;

	private AsyncOperation async;

	IEnumerator LoadLevelWithBar (int nextLevel)
	{
		async = SceneManager.LoadSceneAsync (nextLevel);
		while (!async.isDone) 
		{
			loadingBar.value = async.progress;
			yield return null;
		}
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
//			Fade ();
//			myBlackCG.alpha += Time.deltaTime;
			waitTimeBeforeLoading -= Time.deltaTime;
//			if (myBlackCG.alpha >= 1 && waitTimeBeforeLoading <= 0f) 
			if (waitTimeBeforeLoading <= 0f)
			{
				loadingImage.SetActive (true);
				StartCoroutine (LoadLevelWithBar (nextLevel));
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
