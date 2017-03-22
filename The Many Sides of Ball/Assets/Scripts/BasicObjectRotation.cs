using UnityEngine;
using System.Collections;

public class BasicObjectRotation : MonoBehaviour {

	public float rotationSpeed = 100f;
	public bool rotateLeft = true; 
	public bool rotateUp = false;
    public bool rotateForward = false;

	void Update () 
	{
		if (rotateLeft)
			transform.Rotate (Vector3.up, rotationSpeed * Time.deltaTime);
		if (rotateUp)
			transform.Rotate (Vector3.right, rotationSpeed * Time.deltaTime);
        if (rotateForward)
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
	}
}
