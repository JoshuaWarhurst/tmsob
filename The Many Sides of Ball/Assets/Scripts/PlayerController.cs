using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public enum GAME_TYPE
{
	THIRD_PERSON_FOLLOW,
	TOP_DOWN,
	SIDE_VIEW,
}

public class PlayerController : MonoBehaviour {

	public GAME_TYPE gameType;

    public PLAYER_CAMERA playerCamera;

	[System.Serializable]
	public class MoveSettings
	{
        public float startForwardVel = 12;
        [HideInInspector]
		public float forwardVel = 12;
		public float rotateVel = 50;
		public float accel = 1f;
		public float maxForwardVel = 30; 
		public bool isMoving = false;
        public bool facingBackward = false;
		public float jumpVel = 25;
		public float timeSinceGrounded = 0;
		//new Grounded() settings
		public Vector3 offsetPosition;
		public float sphereRadius = 0.5f;
		public LayerMask ground;
		public LayerMask groundRed;
		public LayerMask groundBlue;
		public LayerMask groundYellow;
	}

	[System.Serializable]
	public class PhysSettings
	{
		public float downAccel = 1f;
		public float maxDownAccel = 2f;
		//pick up and throwing settings
		public Transform HoldPosition; //This is the point where the picked up objects go
		public Transform BigHoldPosition; //This is the point where the big picked up objects go
		public float ThrowForce = 10f; //How strong the throw is. This assumes the picked object has a rigidbody component attached
        public float rotationSpeed = 1f;
	}

	[System.Serializable]
	public class InputSettings
	{
		public float inputDelay = 0.1f;
		public string FORWARD_AXIS = "Vertical";
        public string SIDE_AXIS = "Horizontal";
		public string TURN_AXIS = "Horizontal";
		public string JUMP_AXIS = "Jump";
        public string THROW_AND_FALL_BUTTON = "Fire1";
        public string FLOAT_AND_STOP_BUTTON = "Fire2";
        public string SPEED_BOOST_BUTTON = "Fire3";
	}

	[System.Serializable]
	public class SoundSettings
	{
		public AudioClip jumpSound;
        public float jumpTimer = 0f;
	}

	[System.Serializable]
	public class AbilitySettings
	{
		public bool ableToJump = false;
		public bool ableToLiftSmall = false; //currently unused
		public bool ableToLiftBig = false; //currently unused
		public bool ableToFloat = false;
        public int floatCharges;
        public int maxFloatCharges = 4;
		public bool ableToSpeedBoost = false;
		public bool red = true;
		public bool blue = false;
		public bool yellow = false;
	}

	public MoveSettings moveSetting = new MoveSettings ();
	public PhysSettings physSetting = new PhysSettings ();
	public InputSettings inputSetting = new InputSettings ();
	public SoundSettings soundSetting = new SoundSettings();
	public AbilitySettings abilitySetting = new AbilitySettings ();

	Ray nearRay;
	RaycastHit pickupRayHit;
	int pickupMask;
	private bool carrying;
	private Transform _pickedObject;

	public Vector3 velocity = Vector3.zero;
	private Quaternion targetRotation;

	private Rigidbody rbody;
	private Animator anim;
	private ParticleSystem particle;
	private AudioSource source;

	private CameraController cameraControl;
	float forwardInput, turnInput, jumpInput, sideInput;

	public Quaternion TargetRotation
	{
		get {return targetRotation; }
	}

	void Awake()
	{
		pickupMask = LayerMask.GetMask ("Pickup");
		if (GetComponent<Rigidbody> ())
			rbody = GetComponent<Rigidbody> ();
		else
			Debug.LogError ("The character needs a rigidbody.");
		anim = GetComponent<Animator> ();
		particle = GetComponent<ParticleSystem> ();
		source = GetComponent<AudioSource> ();

		cameraControl = GameObject.Find ("Main Camera").GetComponent<CameraController> ();
	}

	void Start()
	{
        #region set Game Type based on level
        if (SceneManager.GetActiveScene().name == "L1_1")
            gameType = GAME_TYPE.SIDE_VIEW;
        if (SceneManager.GetActiveScene().name == "L1_2")
            gameType = GAME_TYPE.TOP_DOWN;
        if (SceneManager.GetActiveScene().name == "L1_3")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "L2_1")
            gameType = GAME_TYPE.SIDE_VIEW;
        if (SceneManager.GetActiveScene().name == "L2_2")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "L2_3")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "L3_1")
            gameType = GAME_TYPE.TOP_DOWN;
        if (SceneManager.GetActiveScene().name == "L3_2")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "L3_3")
            gameType = GAME_TYPE.SIDE_VIEW;
        if (SceneManager.GetActiveScene().name == "L4_1")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "L4_2")
            gameType = GAME_TYPE.TOP_DOWN;
        if (SceneManager.GetActiveScene().name == "L5_1")
            gameType = GAME_TYPE.SIDE_VIEW;
        if (SceneManager.GetActiveScene().name == "L5_2")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "L5_3")
            gameType = GAME_TYPE.SIDE_VIEW;
        if (SceneManager.GetActiveScene().name == "L5_4")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "L6_1")
            gameType = GAME_TYPE.TOP_DOWN;
        if (SceneManager.GetActiveScene().name == "L6_2")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "L6_3")
            gameType = GAME_TYPE.SIDE_VIEW;
        if (SceneManager.GetActiveScene().name == "L6_4")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "Epilogue")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "P1_1")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "P1_2")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        if (SceneManager.GetActiveScene().name == "P1_3")
            gameType = GAME_TYPE.THIRD_PERSON_FOLLOW;
        #endregion

        targetRotation = transform.rotation;

		forwardInput = turnInput = jumpInput = sideInput = 0;

		//for QuickSave / QuickLoad Function
		if (GameControl.control.IsSceneBeingLoaded) 
		{
//			PlayerState.Instance.localPlayerData = GameControl.Instance.LocalCopyOfData;

			transform.position = new Vector3(
				GameControl.control.PositionX,
				GameControl.control.PositionY,
				GameControl.control.PositionZ + 0.1f);
			
			GameControl.control.IsSceneBeingLoaded = false;

			moveSetting.accel = GameControl.control.ballAccel;
			moveSetting.maxForwardVel = GameControl.control.ballMaxForwardVel;
			moveSetting.jumpVel = GameControl.control.ballJump;
		}
	}

	void GetInput()
	{
		if (gameType == GAME_TYPE.SIDE_VIEW) 
		{
			forwardInput = Input.GetAxis (inputSetting.TURN_AXIS);//interpolated
		} 
		else 
		{
            if (playerCamera == PLAYER_CAMERA.CAMERA_COUPLED_TO_MOVEMENT)
            {
                forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);//interpolated
                turnInput = Input.GetAxis(inputSetting.TURN_AXIS);//interpolated
            }
            else
            {
                forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);//interpolated
                sideInput = Input.GetAxis(inputSetting.SIDE_AXIS);//interpolated
                turnInput = Input.GetAxis(cameraControl.input.ORBIT_HORIZONTAL);//interpolated
            }
        }
		jumpInput = Input.GetAxisRaw (inputSetting.JUMP_AXIS);//non-interpolated
	}

	void Update()
	{
		GetInput ();
		Turn ();
        //        if (abilitySetting.ableToLiftSmall)
        //Pickup ();

        if (moveSetting.isMoving)
            SpinWhileMoving();
		PutDown ();
		QuickSave ();
		QuickLoad ();
        if (soundSetting.jumpTimer >= 0f)
            soundSetting.jumpTimer -= Time.deltaTime;
    }

	void FixedUpdate()
	{
		CheckGroundStatus ();
        CheckCloseGroundStatus();
//		CheckSidesForCamera (); NEEDS WORK
		InitialRun ();
		Run ();
		VerticalMovement ();
		StopOnGround ();
		Fall ();
		if (abilitySetting.ableToFloat /*&& abilitySetting.floatCharges > 0*/) 
			Float ();
		if (abilitySetting.ableToSpeedBoost) 
			SpeedBoost ();
		
		rbody.velocity = transform.TransformDirection (velocity);
	}

	bool Grounded()
	{
		if (abilitySetting.red == true)
			return Physics.CheckSphere (transform.position + moveSetting.offsetPosition, moveSetting.sphereRadius, moveSetting.groundRed);
		if (abilitySetting.blue == true)
			return Physics.CheckSphere (transform.position + moveSetting.offsetPosition, moveSetting.sphereRadius, moveSetting.groundBlue);
		if (abilitySetting.yellow == true)
			return Physics.CheckSphere (transform.position + moveSetting.offsetPosition, moveSetting.sphereRadius, moveSetting.groundYellow);
		else
			return Physics.CheckSphere (transform.position + moveSetting.offsetPosition, moveSetting.sphereRadius, moveSetting.ground);
	}

	/*NEW 
	 * In addition to Grounded(), this does a more general check to see if something is below a player. 
	 * Grounded() is now used for specialty grounds, like RED and BLUE.*/

	[SerializeField] float m_GroundCheckDistance = 0.11f;
	Vector3 m_GroundNormal;
	public bool m_IsGrounded;

	void CheckGroundStatus()
	{
		RaycastHit hitInfo;
		#if UNITY_EDITOR
		// helper to visualise the ground check ray in the scene view
		//		Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * m_GroundCheckDistance));
		Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * 10f));
		#endif
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.SphereCast (transform.position + (Vector3.up * 0.1f), 0.5f, Vector3.down, out hitInfo, m_GroundCheckDistance)) 
		{
			m_GroundNormal = hitInfo.normal;
			m_IsGrounded = true;
            anim.SetBool ("onGround", true);
            abilitySetting.floatCharges = abilitySetting.maxFloatCharges;
//			cameraControl.position.targetPosOffset = new Vector3 (0, +2, 0);
		}
		else
		{
			m_IsGrounded = false;
            anim.SetBool("onGround", false);
            m_GroundNormal = Vector3.up;
//			cameraControl.position.targetPosOffset = new Vector3 (0, -1, 0);
		}
	}

	[SerializeField] float m_SideCheckDistance = 0.2f;

	void CheckSidesForCamera()
	{
		RaycastHit hitInfoLeft;
		RaycastHit hitInfoRight;

		#if UNITY_EDITOR

		Debug.DrawLine(transform.position, Vector3.left, Color.blue);
		Debug.DrawLine(transform.position, Vector3.right, Color.red);
		#endif

		if (Physics.Raycast (transform.position, Vector3.left, out hitInfoLeft))
		{
			cameraControl.position.targetPosOffset = new Vector3 (+3, +0, +0);
		}
		if (Physics.Raycast (transform.position, Vector3.right, out hitInfoRight)) 
		{
			cameraControl.position.targetPosOffset = new Vector3 (-3, +0, +0);
		}
		else
		{
			cameraControl.position.targetPosOffset = new Vector3 (0, 0, 0);
		}

	}

	void OnDrawGizmos()
	{
		//to see the sphere's collider in the Scene View, used in Grounded()
		Gizmos.DrawSphere (transform.position + moveSetting.offsetPosition, moveSetting.sphereRadius);
	}

	private float timeElapsed = 0f;

	//Ball moves at the start of the level
	void InitialRun()
	{
		if (timeElapsed >= 3) 
		{
			velocity.z = 0;
			return;
		} 
		if (timeElapsed >= 2) 
		{
			velocity.z = 1;
			timeElapsed += Time.deltaTime;
		} 
		if (timeElapsed >= 1) 
		{
			velocity.z = 2;
			timeElapsed += Time.deltaTime;
		} 
		else 
		{
			velocity.z = 3;
			timeElapsed += Time.deltaTime;
		}
	}

	void Run()
	{
        if (playerCamera == PLAYER_CAMERA.CAMERA_DECOUPLED_FROM_MOVEMENT)
        {
            if (Mathf.Abs(sideInput) > inputSetting.inputDelay)
            {
                //move
                moveSetting.isMoving = true;
//                cameraControl.hOrbitSnapInput = 1;
                cameraControl.OrbitTarget();
                velocity.x = moveSetting.forwardVel * sideInput;
                moveSetting.forwardVel += moveSetting.accel * Time.deltaTime;
            }
        }
        if (Mathf.Abs (forwardInput) > inputSetting.inputDelay) {
			//move
			moveSetting.isMoving = true;
			cameraControl.hOrbitSnapInput = 1;
			cameraControl.OrbitTarget ();
			velocity.z = moveSetting.forwardVel * forwardInput;
			moveSetting.forwardVel += moveSetting.accel * Time.deltaTime;
            if (forwardInput < 0)
                moveSetting.facingBackward = true;
            else
                moveSetting.facingBackward = false;
                

/* CHANGING CAMERA BASED ON SPEED
 * not using it because messing with player vision could make high-speed platforming more difficult
            if (Camera.main.fieldOfView <= 90)
            {
                Camera.main.fieldOfView += (moveSetting.forwardVel / 100);
            }
            else
            {
                Camera.main.fieldOfView = 90;
            }
*/

            if (gameType == GAME_TYPE.SIDE_VIEW)
            {
                transform.position = new Vector3(0f, transform.position.y, transform.position.z);
            }

			if (moveSetting.forwardVel < 30) 
			{
				particle.Stop ();
			}
			if (moveSetting.forwardVel >= 30) 
			{
				particle.startLifetime = 2;
				particle.startSize = 0.3f;
				particle.startColor = Color.grey;
				particle.Play ();
			}
			if (moveSetting.forwardVel >= 45) 
			{
				particle.startSize = 0.4f;
				particle.startLifetime = 3;
			}
			if (moveSetting.forwardVel >= 60) 
			{
				particle.startSize = 0.5f;
				particle.startLifetime = 4;
				particle.startColor = Color.white;
			}
			if (moveSetting.forwardVel >= 75) 
			{
				particle.startSize = 0.6f;
				particle.startLifetime = 5;
			}
			if (moveSetting.forwardVel >= 90) 
			{
				particle.startSize = 0.7f;
				particle.startLifetime = 6;
				particle.startColor = Color.cyan;
			}
			if (moveSetting.forwardVel > moveSetting.maxForwardVel) 
			{
				moveSetting.forwardVel = moveSetting.maxForwardVel;
			}
		} 
		else if (Mathf.Abs (forwardInput) == 0) 
		{
			if (gameType == GAME_TYPE.TOP_DOWN && (Mathf.Abs(turnInput) > 0)) 
			{
                return;
			} 
			else 
			{
				if (moveSetting.forwardVel > moveSetting.startForwardVel) 
				{
					moveSetting.forwardVel -= 10 * moveSetting.accel * Time.deltaTime;
                //    Camera.main.fieldOfView -= (moveSetting.forwardVel / 50);
                    particle.Stop ();
				} 
				else 
				{
					//speed reset to normal after not moving
					particle.Stop();
                //    Camera.main.fieldOfView = 60;
                    moveSetting.forwardVel = moveSetting.startForwardVel;	
				}
				moveSetting.isMoving = false;
			}
		} 
		else
 		{	//zero velocity
			velocity.z = 0;
			particle.Stop ();
		}
	}

    // Not working as intended
    void SpinWhileMoving()
    {
        this.transform.Translate(0, Random.Range(0, 1), 0);
    }

	void SpeedBoost()
	{
		if (Input.GetButton (inputSetting.SPEED_BOOST_BUTTON)) 
		{
			moveSetting.forwardVel = moveSetting.forwardVel * 1.5f;
			moveSetting.maxForwardVel = 40;
		} 
	}

	public void ChangeColor()
	{
		//turn red
		if (abilitySetting.red == true) 
		{
			Color newColor = new Color (255, 0, 0);
            NewColor(newColor);
        }

		//turn blue
		if (abilitySetting.blue == true) 
		{
			Color newColor = new Color (0, 0, 255);
            NewColor(newColor);
        }

		//turn yellow
		if (abilitySetting.yellow == true)
		{
			Color newColor = new Color (255, 255, 0);
            NewColor(newColor);
		}
	}

    void NewColor(Color newColor)
    {
        gameObject.GetComponent<Renderer>().material.color = newColor;
    }

	void Turn()
	{
		switch (gameType) 
		{
		case GAME_TYPE.THIRD_PERSON_FOLLOW:
			if (Mathf.Abs (turnInput) > inputSetting.inputDelay) {
				targetRotation *= Quaternion.AngleAxis (moveSetting.rotateVel * turnInput * Time.deltaTime, Vector3.up);
			}
			transform.rotation = targetRotation;
			break;
		case GAME_TYPE.TOP_DOWN:
			if (Mathf.Abs (turnInput) > inputSetting.inputDelay) 
			{
				//becomes move function in top down mode
				moveSetting.isMoving = true;
				cameraControl.hOrbitSnapInput = 1;
				cameraControl.OrbitTarget ();
				velocity.x = moveSetting.forwardVel * turnInput;
				moveSetting.forwardVel += moveSetting.accel * Time.deltaTime;
			//	targetRotation *= Quaternion.AngleAxis (moveSetting.rotateVel * turnInput * Time.deltaTime, Vector3.up);
			}
			if (moveSetting.forwardVel > moveSetting.maxForwardVel) 
			{
				moveSetting.forwardVel = moveSetting.maxForwardVel;
			}
			transform.rotation = targetRotation;
			break;
		case GAME_TYPE.SIDE_VIEW:
			break;
		}
	}

	//jump
	void VerticalMovement()
	{
		if (jumpInput > 0 && (m_IsGrounded || Grounded())) 
		{
			Jump ();
		} 
		if (jumpInput > 0 && moveSetting.timeSinceGrounded < 0.2f) 
		{
			Jump ();
		}
		else if (jumpInput == 0 && (m_IsGrounded || Grounded())) 
		{
			//zero out our velocity.y
//			anim.SetBool ("onGround", true);
			velocity.y = 0;
			moveSetting.timeSinceGrounded = 0;
		} 
		else 
		{
			//decrease velocity.y
//			anim.SetBool ("onGround", false);
			velocity.y -= physSetting.downAccel;
			moveSetting.timeSinceGrounded += Time.deltaTime;
			if (velocity.y <= -physSetting.maxDownAccel && m_IsCloseToGround) 
			{
				velocity.y = -physSetting.maxDownAccel;
			}
		}
	}

    [SerializeField]
    float m_CloseGroundCheckDistance = 0.5f;
    public bool m_IsCloseToGround;

    void CheckCloseGroundStatus()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * 10f));
#endif
        if (Physics.SphereCast(transform.position + (Vector3.up * 0.1f), 0.5f, Vector3.down, out hitInfo, m_CloseGroundCheckDistance))
        {
            m_IsCloseToGround = true;
            m_GroundNormal = hitInfo.normal;
        }
        else
        {
            m_IsCloseToGround = false;
            m_GroundNormal = Vector3.up;
        }
    }

    void Jump()
	{
		if (abilitySetting.ableToJump == true) 
		{
            if (soundSetting.jumpTimer <= 0)
            {
                source.pitch = Random.Range(1.2f, 1.4f);
                source.volume = Random.Range(0.06f, 0.14f);
                source.PlayOneShot(soundSetting.jumpSound, 0.5f);
            }
            anim.SetTrigger("jump");
//            anim.SetBool("onGround", false);
            soundSetting.jumpTimer = 0.1f;
            velocity.y = moveSetting.jumpVel + (moveSetting.forwardVel / 12);
			moveSetting.timeSinceGrounded = 100; //100 is arbitrary, just so can't jump again at the top of jump arc
			velocity.z = 0;
            if (gameType == GAME_TYPE.TOP_DOWN)
                velocity.x = 0;
		}
	}

	void Fall()
	{
		if (Input.GetButton (inputSetting.THROW_AND_FALL_BUTTON)) 
		{
			velocity.y -= physSetting.downAccel * 2;
			moveSetting.timeSinceGrounded += Time.deltaTime;
            particle.startSize = 0.7f;
            particle.startLifetime = 6;
            particle.startColor = Color.red;
            particle.Play();
        }
    }

	//stay in place when pressing a button in midair
	void Float()
	{
        if (!m_IsGrounded && Input.GetButtonDown(inputSetting.FLOAT_AND_STOP_BUTTON))
        {
            abilitySetting.floatCharges--;
        }
        if (!m_IsGrounded && Input.GetButton (inputSetting.FLOAT_AND_STOP_BUTTON))
        {
			velocity.x = velocity.y = velocity.z = 0;
			particle.startLifetime = 5;
			particle.startSize = 0.3f;
			particle.startColor = Color.yellow;
			particle.Play ();
		}
    }

	void StopOnGround()
	{
		if (m_IsGrounded && Input.GetButton (inputSetting.FLOAT_AND_STOP_BUTTON))
        {
			velocity.x = velocity.y = velocity.z = 0;
            moveSetting.forwardVel += moveSetting.accel * 3 * Time.deltaTime;
        }
	}

	void OnCollisionEnter (Collision collision)
	{
        if (abilitySetting.ableToLiftSmall)
        {
            if (collision.transform.tag == "Pickup" || collision.transform.tag == "Pickup1" || collision.transform.tag == "Pickup2" || collision.transform.tag == "Pickup3")
            {
                if (carrying == false)
                {
                    //caches the picked object
                    _pickedObject = collision.transform;

                    _pickedObject.GetComponent<Rigidbody>().useGravity = false;
                    _pickedObject.GetComponent<Rigidbody>().isKinematic = true;

                    //this will snap the picked object to the "hands" of the player
                    _pickedObject.position = physSetting.HoldPosition.position;

                    //this will set the HoldPosition as the parent of the pickup so it will stay there
                    _pickedObject.parent = physSetting.HoldPosition;

                    carrying = true;

                    physSetting.ThrowForce = 1f;
                }
            }
        }

		if (collision.transform.tag == "BigPickup") 
		{
			if (carrying == false) 
			{
                //caches the picked object
					_pickedObject = collision.transform;

					_pickedObject.GetComponent<Rigidbody> ().useGravity = false;
					_pickedObject.GetComponent<Rigidbody> ().isKinematic = true;

					//this will snap the picked object to the "hands" of the player
					_pickedObject.position = physSetting.BigHoldPosition.position;

					//this will set the BigHoldPosition as the parent of the pickup so it will stay there
					_pickedObject.parent = physSetting.BigHoldPosition;

					carrying = true;
					physSetting.ThrowForce = 0.5f;
					abilitySetting.ableToJump = false;
			}
		}
	}

	//for throwing a picked up item
	void PutDown()
	{
		if (Input.GetButtonDown(inputSetting.THROW_AND_FALL_BUTTON))
		{
            if (_pickedObject != null)
            {
                //resets the pickup's parent to null so it won't keep following the player
                _pickedObject.parent = null;

                _pickedObject.GetComponent<Rigidbody>().useGravity = true;
                _pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                //applies force to the rigidbody to create a throw
                if (moveSetting.facingBackward)
                { _pickedObject.GetComponent<Rigidbody>().AddForce(-transform.forward * physSetting.ThrowForce * 100 * ((velocity.z / 10) + 1), ForceMode.Impulse); }
                else
                { _pickedObject.GetComponent<Rigidbody>().AddForce(transform.forward * physSetting.ThrowForce * 100 * ((velocity.z / 10) + 1), ForceMode.Impulse); }
                _pickedObject.GetComponent<Rigidbody>().AddForce(transform.up * 5, ForceMode.Impulse);

				//resets the _pickedObject 
				_pickedObject = null;

				carrying = false;

				abilitySetting.ableToJump = true;
			}
		}
	}

	void QuickSave()
	{
		if (Input.GetKey (KeyCode.F5)) 
		{
			GameControl.control.SceneID = SceneManager.GetActiveScene ().buildIndex;
			GameControl.control.PositionX = transform.position.x;
			GameControl.control.PositionY = transform.position.y;
			GameControl.control.PositionZ = transform.position.z;

			GameControl.control.ballAccel = moveSetting.accel;
			GameControl.control.ballMaxForwardVel = moveSetting.maxForwardVel;
			GameControl.control.ballJump = moveSetting.jumpVel;

			GameControl.control.Save ();
		}
	}
		
	void QuickLoad()
	{
		if (Input.GetKey (KeyCode.F9)) 
		{
			GameControl.control.Load ();
			GameControl.control.IsSceneBeingLoaded = true;

			int whichScene = GameControl.control.SceneID;

			SceneManager.LoadScene (whichScene);
		}
	}

}