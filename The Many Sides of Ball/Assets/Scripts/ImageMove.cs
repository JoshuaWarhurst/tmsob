using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour {

    public float waitToStart = 1f;
    public RectTransform image;
    private float time = 0;

    void Update()
    {
        waitToStart -= Time.deltaTime;
        image.localScale = new Vector3(time, 1, 1);
        if (waitToStart <= 0f)
        {
            Activate();
        }
    }

    void Activate()
    {
        if (time >= 1)
            return;
        else
            time += Time.deltaTime;
    }
}
