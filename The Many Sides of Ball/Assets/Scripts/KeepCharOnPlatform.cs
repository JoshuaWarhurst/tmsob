using UnityEngine;
using System.Collections;

public class KeepCharOnPlatform : MonoBehaviour 
{
	public struct Data
	{
		public Data (PlayerController ctrl, Transform t, float yOffset) 
		{
			this.ctrl = ctrl;
			this.t = t;
			this.yOffset = yOffset;
		}
		public PlayerController ctrl;
		public Transform t;
		public float yOffset;
	};
	public float verticalOffset = 0.25f;
	private Hashtable onPlatform = new Hashtable ();
	private Vector3 lastPos;
	void OntriggerEnter(Collider other)
	{
		PlayerController ctrl = other.GetComponent (typeof(PlayerController)) as PlayerController;
		if (ctrl == null) return;
		Transform t = other.transform;
		float yOffset = 0.5f - ctrl.transform.position.y + verticalOffset;
		Data data = new Data (ctrl, t, yOffset);
		onPlatform.Add (other.transform, data);
	}
	void OntriggerExit(Collider other)
	{
		onPlatform.Remove (other.transform);
	}
	void Start()
	{
		lastPos = transform.position;
	}
	void Update()
	{
		Vector3 curPos = transform.position;
		float y = curPos.y;
		Vector3 delta = curPos - lastPos;
		float yVelocity = delta.y;
		delta.y = 0f;
		lastPos = curPos;
		foreach (DictionaryEntry d in onPlatform) {
			Data data = (Data)d.Value;
			float charYVelocity = data.ctrl.velocity.y;
			if ((charYVelocity <= 0f) || (charYVelocity <= yVelocity))
			{
				Vector3 pos = data.t.position;
				pos.y = y + data.yOffset;
				pos += delta;
				data.t.position = pos;
			}
		}
	}

}
