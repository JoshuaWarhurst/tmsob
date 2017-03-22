using UnityEngine;
using System.Collections;

/// <summary>
/// Creates wandering behaviour for a CharacterController.
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class NPCWander : MonoBehaviour
{
	public float speed = 5;
	public float directionChangeInterval = 1;
	public float maxHeadingChange = 30;

	CharacterController controller;
	float heading;
	Vector3 targetRotation;

	public Vector3 startPosition;
	public float minX;
	public float maxX;
	public float minZ;
	public float maxZ;

	public bool inRange;
    public bool initialMovement = true;

	void Awake ()
	{
		controller = GetComponent<CharacterController>();

		startPosition = transform.position;
		minX += transform.position.x;
		maxX += transform.position.x;
		minZ += transform.position.z;
		maxZ += transform.position.z;

		// Set random initial rotation
		heading = Random.Range(0, 360);
		transform.eulerAngles = new Vector3(0, heading, 0);

		StartCoroutine(NewHeading());
	}

	void Update ()
	{
		if (inRange || initialMovement)
        {
			transform.eulerAngles = Vector3.Slerp (transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
			var forward = transform.TransformDirection (Vector3.forward);
			controller.SimpleMove (forward * speed);	
		}
        else 
		{
			return;
		}
	}

	/// <summary>
	/// Repeatedly calculates a new direction to move towards.
	/// Use this instead of MonoBehaviour.InvokeRepeating so that the interval can be changed at runtime.
	/// </summary>
	IEnumerator NewHeading ()
	{
		while (true) 
		{
			NewHeadingRoutine ();
			yield return new WaitForSeconds (directionChangeInterval);
            if (initialMovement)
                initialMovement = false;
		}
	}

	/// <summary>
	/// Calculates a new direction to move towards.
	/// </summary>
	void NewHeadingRoutine ()
	{		
		if (transform.position.x <= minX) 
		{
			transform.eulerAngles = new Vector3(0, 90, 0);
		}
		if (transform.position.x >= maxX) 
		{
			transform.eulerAngles = new Vector3(0, -90, 0);
		}
		if (transform.position.z <= minZ) 
		{
			transform.eulerAngles = new Vector3(0, 0, 0);
		}
		if (transform.position.z >= maxZ) 
		{
			transform.eulerAngles = new Vector3(0, 180, 0);
		} 
		else 
		{
			var floor = Mathf.Clamp(heading - maxHeadingChange, 0, 360);
			var ceil  = Mathf.Clamp(heading + maxHeadingChange, 0, 360);		
			heading = Random.Range (floor, ceil);
			targetRotation = new Vector3(0, heading, 0);
		}
	}
		
	void OnTriggerStay()
	{
		inRange = true;
        initialMovement = false;
	}

	void OnTriggerExit ()
	{
		inRange = false;
	}

	void WaitingAround ()
	{
		
	}
}