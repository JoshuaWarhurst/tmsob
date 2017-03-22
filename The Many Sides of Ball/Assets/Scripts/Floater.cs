using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Floater : MonoBehaviour {
	
	public float waterLevel, floatHeight;
	public Vector3 buoyancyCentreOffset;
	public float bounceDamp;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	void FixedUpdate () 
	{
		Vector3 actionPoint = transform.position + transform.TransformDirection(buoyancyCentreOffset);
		float forceFactor = 1f - ((actionPoint.y - waterLevel) / floatHeight);
		
		if (forceFactor > 0f) 
		{
			Vector3 uplift = -Physics.gravity * (forceFactor - rb.velocity.y * bounceDamp);
			rb.AddForceAtPosition(uplift, actionPoint);
		}
	}
}
