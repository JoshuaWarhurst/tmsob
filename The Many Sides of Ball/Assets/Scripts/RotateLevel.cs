using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLevel : MonoBehaviour {

    public GameObject level;
    public GameObject pivotPoint;
    public float rotationSpeed = 50f;

    public bool rotateLeft = true;
    public bool rotateUp = false;
    public bool rotateToward = false;

    private bool rotating = false;

    private void OnCollisionEnter(Collision collision)
    {
        pivotPoint.transform.SetParent(null);
        level.transform.SetParent(pivotPoint.transform);
        if (collision.transform.tag == "Player")
            if (rotating)
                rotating = false;
            else
                rotating = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        rotating = false;
        level.transform.SetParent(null);
        pivotPoint.transform.SetParent(level.transform);
    }

    void Update()
    {
        if (rotating)
        {
            if (rotateLeft)
                pivotPoint.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            if (rotateUp)
                pivotPoint.transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime);
            if (rotateToward)
                pivotPoint.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        }
    }
}
