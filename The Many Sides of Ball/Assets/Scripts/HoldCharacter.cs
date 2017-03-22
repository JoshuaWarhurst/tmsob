using UnityEngine;
using System.Collections;

public class HoldCharacter : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		col.transform.parent = gameObject.transform;
	}

	void OnCollisionExit(Collision col)
	{
		col.transform.parent = null;
	}
}
