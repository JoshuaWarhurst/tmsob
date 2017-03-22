using UnityEngine;
using System.Collections;

public enum CAMERA_TYPE
{
	THIRD_PERSON_FOLLOW,
	TOP_DOWN,
	SIDE_VIEW,
}

public enum PLAYER_CAMERA
{
    CAMERA_COUPLED_TO_MOVEMENT,
    CAMERA_DECOUPLED_FROM_MOVEMENT,
}

public class CameraController : MonoBehaviour {

	public CAMERA_TYPE cameraType;

    public PLAYER_CAMERA playerCamera = PLAYER_CAMERA.CAMERA_COUPLED_TO_MOVEMENT;

	public Transform target;

	[System.Serializable]
	public class PositionSettings
	{
		public Vector3 targetPosOffset = new Vector3 (0, 0, 0);
		public float lookSmooth = 25f;
		public float distanceFromTarget = -8;
		public float zoomSmooth = 100;
		public float maxZoom = -2;
		public float minZoom = -15;
		public bool smoothFollow = true;
		public float smooth = 0.05f;
        public bool cameraMinHeight = false;
        public float minHeight = -10f;

		[HideInInspector]
		public float newDistance = -8; //set by zoom input
		[HideInInspector]
		public float adjustmentDistance = -8;
	}

	[System.Serializable]
	public class OrbitSettings
	{
		public float xRotation = -20;
		public float yRotation = -180;
		public float maxXRotation = 25;
		public float minXRotation = -85;
		public float vOrbitSmooth = 150;
		public float hOrbitSmooth = 150;
	}

	[System.Serializable]
	public class InputSettings
	{
		public string ORBIT_HORIZONTAL_SNAP = "OrbitHorizontalSnap";
		public string ORBIT_HORIZONTAL = "OrbitHorizontal";
		public string ORBIT_VERTICAL = "OrbitVertical";
		public string ZOOM = "Mouse ScrollWheel";
	}

	[System.Serializable]
	public class DebugSettings
	{
		public bool drawDesiredCollisionLines = true;
		public bool drawAdjustedCollisionLines = true;
	}

	public PositionSettings position = new PositionSettings ();
	public OrbitSettings orbit = new OrbitSettings ();
	public InputSettings input = new InputSettings ();
	public DebugSettings debug = new DebugSettings ();
	public CollisionHandler collision = new CollisionHandler ();

	Vector3 targetPos = Vector3.zero;
	Vector3 destination = Vector3.zero;
	Vector3 adjustedDestination = Vector3.zero; //new
	Vector3 camVel = Vector3.zero; //new
	CharacterController charController;
    private float vOrbitInput, hOrbitInput, zoomInput, mouseOrbitInput, vMouseOrbitInput;
    [HideInInspector]
    public float hOrbitSnapInput; 

	void Start()
	{
		SetCameraTarget (target);

		vOrbitInput = hOrbitInput = zoomInput = hOrbitSnapInput = mouseOrbitInput = vMouseOrbitInput = 0;

		MoveToTarget ();

		collision.Initialize (Camera.main);
		collision.UpdateCameraClipPoints (transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
		collision.UpdateCameraClipPoints (destination, transform.rotation, ref collision.desiredCameraClipPoints);

		switch (cameraType)
		{
		case CAMERA_TYPE.THIRD_PERSON_FOLLOW:
			break;
		case CAMERA_TYPE.TOP_DOWN:
			position.targetPosOffset += new Vector3 (0, 10, 0);
			position.distanceFromTarget = -8;
			position.maxZoom = -100;
			position.minZoom = -100;
			orbit.xRotation = -85;
			orbit.minXRotation = -85;
			orbit.maxXRotation = -85;
			break;
		case CAMERA_TYPE.SIDE_VIEW:
			position.targetPosOffset = new Vector3 (5, 5, 0);
			position.distanceFromTarget = -40;
			position.maxZoom = -2;
			position.minZoom = -40;
			orbit.xRotation = -30;
			orbit.minXRotation = -40;
			orbit.maxXRotation = 10;
			break;
		}
	}

	public void SetCameraTarget(Transform t)
	{
		target = t;

		if (target != null) 
		{
			if (target.GetComponent<CharacterController> ()) 
			{
				charController = target.GetComponent<CharacterController> ();
			} 
//			else
//				Debug.LogError ("The camera's target needs a character controller.");
		} 
		else
			Debug.LogError ("Your camera needs a target.");
	}

	void GetInput()
	{
		vOrbitInput = Input.GetAxisRaw (input.ORBIT_VERTICAL);
		hOrbitInput = Input.GetAxisRaw (input.ORBIT_HORIZONTAL);
		hOrbitSnapInput = Input.GetAxisRaw (input.ORBIT_HORIZONTAL_SNAP);
		zoomInput = Input.GetAxisRaw (input.ZOOM);
	}

	void Update()
	{
		GetInput ();
		ZoomInOnTarget ();
	}

    void FixedUpdate()
    {
        if (position.cameraMinHeight)
        {
            if (target.transform.position.y <= position.minHeight)
            {
                return;
            }
            else
            {
                MoveToTarget();
                LookAtTarget();
            }
        }
        else
        {
            MoveToTarget();
            LookAtTarget();
        }
        OrbitTarget ();
		switch (cameraType) 
		{
		case CAMERA_TYPE.THIRD_PERSON_FOLLOW:
			break;
		case CAMERA_TYPE.TOP_DOWN:
			break;
		case CAMERA_TYPE.SIDE_VIEW:
			break;
		}

		collision.UpdateCameraClipPoints (transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
		collision.UpdateCameraClipPoints (destination, transform.rotation, ref collision.desiredCameraClipPoints);

		//draw debug lines
		for (int i = 0; i < 5; i++) 
		{
			if (debug.drawDesiredCollisionLines) 
			{
				Debug.DrawLine (targetPos, collision.desiredCameraClipPoints [i], Color.white);
			}
			if (debug.drawAdjustedCollisionLines) 
			{
				Debug.DrawLine (targetPos, collision.adjustedCameraClipPoints [i], Color.green);
			}
		}

		collision.CheckColliding (targetPos); //using raycasts here
		position.adjustmentDistance = collision.GetAdjustedDistanceWithRayFrom(targetPos);
	}

	void MoveToTarget()
	{
		targetPos = target.position + Vector3.up * position.targetPosOffset.y + Vector3.forward * position.targetPosOffset.z + transform.TransformDirection(Vector3.right * position.targetPosOffset.x); //new
		destination = Quaternion.Euler (orbit.xRotation, orbit.yRotation + target.eulerAngles.y, 0) * -Vector3.forward * position.distanceFromTarget;
		destination += targetPos;

		if (collision.colliding) 
		{
			adjustedDestination = Quaternion.Euler (orbit.xRotation, orbit.yRotation + target.eulerAngles.y, 0) * Vector3.forward * position.adjustmentDistance;
			adjustedDestination += targetPos;

			if (position.smoothFollow) 
			{
				//use smooth damp function
				transform.position = Vector3.SmoothDamp (transform.position, adjustedDestination, ref camVel, position.smooth);
			} 
			else
				transform.position = adjustedDestination;
		} 
		else 
		{
			if (position.smoothFollow) 
			{
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref camVel, position.smooth);
			} 
			else
				transform.position = destination;
		}
	}

	void LookAtTarget()
	{
		Quaternion targetRotation = Quaternion.LookRotation (targetPos - transform.position);
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, position.lookSmooth * Time.deltaTime);
	}

	public void OrbitTarget()
	{
		if (hOrbitSnapInput > 0) 
		{
			if (cameraType == CAMERA_TYPE.SIDE_VIEW) 
			{
				orbit.yRotation = 90;
			} 
			else 
			{
				orbit.yRotation = -180;
			}
		}

		orbit.xRotation += -vOrbitInput * orbit.vOrbitSmooth * Time.deltaTime;
		if (cameraType != CAMERA_TYPE.SIDE_VIEW) //side view camera doesn't rotate around character
		{
			orbit.yRotation += -hOrbitInput * orbit.hOrbitSmooth * Time.deltaTime;
		}

		if (orbit.xRotation > orbit.maxXRotation) 
		{
			orbit.xRotation = orbit.maxXRotation;
		}

		if (orbit.xRotation < orbit.minXRotation) 
		{
			orbit.xRotation = orbit.minXRotation;
		}
	}

	void ZoomInOnTarget ()
	{
		position.distanceFromTarget += zoomInput * position.zoomSmooth * Time.deltaTime;

		if (position.distanceFromTarget > position.maxZoom) 
		{
			position.distanceFromTarget = position.maxZoom;
		}

		if (position.distanceFromTarget < position.minZoom) 
		{
			position.distanceFromTarget = position.minZoom;
		}
	}

	[System.Serializable]
	public class CollisionHandler
	{
		public LayerMask collisionLayer;

		public CAMERA_TYPE cameraType;

		[HideInInspector]
		public bool colliding = false;
		[HideInInspector]
		public Vector3[] adjustedCameraClipPoints;
		[HideInInspector]
		public Vector3[] desiredCameraClipPoints;

		Camera camera;

		public void Initialize(Camera cam)
		{
			camera = cam;
			adjustedCameraClipPoints = new Vector3[5];
			desiredCameraClipPoints = new Vector3[5];
		}

		public void UpdateCameraClipPoints(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] intoArray)
		{
			if (!camera)
				return;

			//clear the contents of intoArray
			intoArray = new Vector3[5];

			float z = camera.nearClipPlane;
			float x = Mathf.Tan (camera.fieldOfView / 5f) * z; //<play around with this float value to change how intensely occlusion works
			float y = x / camera.aspect;

			//top left
			intoArray[0] = (atRotation * new Vector3(-x, y, z)) + cameraPosition; //added and rotated the point relative to camera
			//top right
			intoArray[1] = (atRotation * new Vector3(x, y, z)) + cameraPosition; //added and rotated the point relative to camera
			//bottom left
			intoArray[2] = (atRotation * new Vector3(-x, -y, z)) + cameraPosition; //added and rotated the point relative to camera
			//bottom right
			intoArray[3] = (atRotation * new Vector3(x, -y, z)) + cameraPosition; //added and rotated the point relative to camera
			//camera's position
			intoArray[4] = cameraPosition - camera.transform.forward;
		}

		bool CollisionDetectedAtClipPoints(Vector3[] clipPoints, Vector3 fromPosition)
		{
			for (int i = 0; i < clipPoints.Length; i++) 
			{
				Ray ray = new Ray(fromPosition, clipPoints[i] - fromPosition);
				float distance = Vector3.Distance(clipPoints[i], fromPosition);
				if (Physics.Raycast (ray, distance, collisionLayer)) 
				{
					return true;
				}
			}

			return false;
		}

		public float GetAdjustedDistanceWithRayFrom(Vector3 from)
		{
			float distance = -1;

			for (int i = 0; i < desiredCameraClipPoints.Length; i++) 
			{
				Ray ray = new Ray(from, desiredCameraClipPoints[i] - from);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) 
				{
					if (distance == -1)
						distance = hit.distance;
					else 
					{
						if (hit.distance < distance)
							distance = hit.distance;
					}
				}
			}

			if (distance == -1)
				return 0;
			else
				return distance;
		}

		public void CheckColliding(Vector3 targetPosition)
		{
			if (CollisionDetectedAtClipPoints (desiredCameraClipPoints, targetPosition)) 
			{
				if (cameraType == CAMERA_TYPE.THIRD_PERSON_FOLLOW) 
				{
					colliding = true;
				} 
				else 
				{
					colliding = false;
				}
			} 
			else 
			{
				colliding = false;
			}
		}
	}
}

