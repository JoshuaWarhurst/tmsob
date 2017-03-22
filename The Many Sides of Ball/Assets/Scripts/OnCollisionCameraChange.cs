using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionCameraChange : MonoBehaviour {

    public PlayerController player;

    public GameObject newCamera;

    public float waitToStart = 1f;
    public float cameraOnTime = 3f;

    private bool playing = false;
    private bool played = false;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        newCamera.SetActive(false);
    }

    private void Update()
    {
        if (playing)
        {
            player.velocity.x = player.velocity.y = player.velocity.z = 0;
        }
    } 

    private void OnCollisionEnter(Collision collision)
    {
        if (played)
        {
            return;
        }
        else
        {
            StartCoroutine(TurnOnOffCamera());
        }
    }

    IEnumerator TurnOnOffCamera()
    {
        yield return new WaitForSeconds(waitToStart);
        playing = true;
        newCamera.SetActive(true);
        yield return new WaitForSeconds(cameraOnTime);
        playing = false;
        newCamera.SetActive(false);
        played = true;
    }

}
