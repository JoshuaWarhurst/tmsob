using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleToZero : MonoBehaviour {

    public float scaleDownRate = 1f;
    private void Update()
    {
        if (transform.localScale.x >= 0 || transform.localScale.y >= 0 || transform.localScale.z >= 0)
            transform.localScale -= new Vector3(1, 1, 1) * scaleDownRate * Time.deltaTime;
        else
            Destroy(gameObject);
    }
}
