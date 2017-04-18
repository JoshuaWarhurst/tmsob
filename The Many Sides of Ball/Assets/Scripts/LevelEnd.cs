using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelEnd: MonoBehaviour {

	public string nextLevel = "_World Map";
    public bool specialCase = false;
	public float waitTimeBeforeLoading = 3f;

	private bool endScene = false;

    private void Start()
    {
        #region set Game Type based on level
        if (SceneManager.GetActiveScene().name == "L1_1")
            nextLevel = "L1_2";
        if (SceneManager.GetActiveScene().name == "L1_2")
            nextLevel = "L1_3";
        if (SceneManager.GetActiveScene().name == "L1_3")
            if (specialCase)
                nextLevel = "_DEMO_END";
            else
                nextLevel = "L2_1";
        if (SceneManager.GetActiveScene().name == "L2_1")
            nextLevel = "L2_2";
        if (SceneManager.GetActiveScene().name == "L2_2")
            if (specialCase)
                nextLevel = "_DEMO_END";
            else
                nextLevel = "L2_3";
        if (SceneManager.GetActiveScene().name == "L2_3")
            nextLevel = "L3_1";
        if (SceneManager.GetActiveScene().name == "L3_1")
            nextLevel = "L3_2";
        if (SceneManager.GetActiveScene().name == "L3_2")
            if (specialCase)
                nextLevel = "L3_2 Cutscene";
            else
                nextLevel = "L3_3";
        if (SceneManager.GetActiveScene().name == "L3_2 Cutscene")
            nextLevel = "L3_3";
        if (SceneManager.GetActiveScene().name == "L3_3")
            nextLevel = "L4_1";
        if (SceneManager.GetActiveScene().name == "L4_1")
            nextLevel = "L4_2";
        if (SceneManager.GetActiveScene().name == "L4_2")
            nextLevel = "L5_1";
        if (SceneManager.GetActiveScene().name == "L5_1")
            nextLevel = "L5_2";
        if (SceneManager.GetActiveScene().name == "L5_2")
            nextLevel = "L5_4";
        if (SceneManager.GetActiveScene().name == "L5_3")
            nextLevel = "L5_4";
        if (SceneManager.GetActiveScene().name == "L5_4")
            nextLevel = "L6_1";
        if (SceneManager.GetActiveScene().name == "L6_1")
            nextLevel = "L6_2";
        if (SceneManager.GetActiveScene().name == "L6_2")
            nextLevel = "L6_3";
        if (SceneManager.GetActiveScene().name == "L6_3")
            nextLevel = "L6_4";
        if (SceneManager.GetActiveScene().name == "L6_4")
            nextLevel = "Epilogue";
        if (SceneManager.GetActiveScene().name == "Epilogue")
            nextLevel = "_Credits";
        if (SceneManager.GetActiveScene().name == "P1_1")
            nextLevel = "_World Map";
        if (SceneManager.GetActiveScene().name == "P1_2")
            nextLevel = "_World Map";
        if (SceneManager.GetActiveScene().name == "P1_3")
            nextLevel = "_World Map";
        if (SceneManager.GetActiveScene().name == "P1_4")
            nextLevel = "_World Map";
        #endregion
    }

    public void LoadScene(string nextLevel)
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
