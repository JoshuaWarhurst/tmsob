using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeactivate : MonoBehaviour {

    public float turnOffIn = 1f;

	void Start ()
    {
        StartCoroutine(TurnOff());
	}

    IEnumerator TurnOff()
    {
        yield return new WaitForSeconds(turnOffIn);
        gameObject.SetActive(false);
    }
}
