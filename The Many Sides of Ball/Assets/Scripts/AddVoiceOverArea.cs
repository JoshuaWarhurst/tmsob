using UnityEngine;
using System.Collections;

public class AddVoiceOverArea : MonoBehaviour {

    public GameObject[] voiceOverGameobjects;
    public float averageWaitTimeBetween = 2f;
    public bool randomWaitTime = false;
    private float waitTime = 0f;
    private bool inRange = false;

	void OnTriggerEnter (Collider collision)
	{
		if (collision.transform.tag == "Player") 
		{
            inRange = true;
            StartCoroutine(PlaySubtitles());
        }
	}

    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            inRange = false;
            StopCoroutine(PlaySubtitles());
        }
    }

    IEnumerator PlaySubtitles()
    {
        foreach (GameObject voiceOverGameobject in voiceOverGameobjects)
        {
            if (inRange && voiceOverGameobject.activeSelf == false)
            {
                if (randomWaitTime)
                    averageWaitTimeBetween = Random.Range(1f, 5f);
                yield return new WaitForSeconds(averageWaitTimeBetween);
                voiceOverGameobject.SetActive(true);
                yield return new WaitForSeconds(0f);
                waitTime = voiceOverGameobject.GetComponent<AddVoiceOver>().subtitleTime;
                yield return new WaitForSeconds(waitTime);
            }
        }

    }
}
