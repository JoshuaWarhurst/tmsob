using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnOff : MonoBehaviour {

    public GameObject turnOff;
    public GameObject turnOn;

    public float waitToStart = 0.1f;

    IEnumerator TurnOnOffObjects()
    {
        yield return new WaitForSeconds(waitToStart);
        turnOff.SetActive(false);
        turnOn.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            StartCoroutine(TurnOnOffObjects());
        }
    }
}
