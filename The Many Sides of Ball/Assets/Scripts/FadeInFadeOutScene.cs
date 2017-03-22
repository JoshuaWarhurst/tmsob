using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInFadeOutScene : MonoBehaviour {

    public PlayerController player;

    public float fadeOutTime = 3f;

    private bool playing = false;
    private bool played = false;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playing)
        {
            player.velocity.x = player.velocity.y = player.velocity.z = 0;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (played)
            {
                return;
            }
            else
            {
                StartCoroutine(FadeInAndOut());
            }
        }
    }

    IEnumerator FadeInAndOut()
    {
        playing = true;
        GameObject.Find("GM").GetComponent<Fading>().fadeDir = 1;
        yield return new WaitForSeconds(fadeOutTime);
        GameObject.Find("GM").GetComponent<Fading>().fadeDir = -1;
        playing = false;
        played = true;
    }
}
