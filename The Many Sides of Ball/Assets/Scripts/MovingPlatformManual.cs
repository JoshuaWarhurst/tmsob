using UnityEngine;
using System.Collections;

public class MovingPlatformManual : MonoBehaviour {

	public float platformSpeed = 1;
	public float platformMoveX;
	public float platformMoveY;
	public float platformMoveZ;
	public float StartEndHoldTime = 0f;
	public float startDelay = 0f;

	private Transform platformStartPos;
	private float platformStartPosX;
	private float platformStartPosY;
	private float platformStartPosZ;

	private bool completeX;
	private bool completeY;
	private bool completeZ;
	private float countdown;

	public enum PLATFORM_STATE
	{
		START,
		MOVING_TOWARDS,
		END,
		MOVING_AWAY,
	}
	public PLATFORM_STATE myPlatformState = PLATFORM_STATE.START;

	void Start ()
	{
		platformStartPosX = transform.position.x;
		platformStartPosY = transform.position.y;
		platformStartPosZ = transform.position.z;
		completeX = completeY = completeZ = false;
		countdown = StartEndHoldTime;
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Player") 
		{
			other.transform.parent = this.transform;
            if (other.transform.localScale != this.transform.localScale)
            {
                //TODO
            }
		}
	}

	void OnCollisionExit(Collision other)
	{
		if (other.transform.tag == "Player") 
		{
			other.transform.parent = null;
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (new Vector3 
			(this.transform.position.x + platformMoveX, 
			this.transform.position.y + platformMoveY, 
			this.transform.position.z + platformMoveZ), this.transform.localScale);
	}

	void FixedUpdate ()
	{
		if (startDelay > 0) {
			startDelay -= Time.deltaTime;
		} else {
			switch (myPlatformState) {
			case PLATFORM_STATE.START:
				if (countdown > 0) {
					countdown -= Time.deltaTime;
				} else
					myPlatformState = PLATFORM_STATE.MOVING_TOWARDS;
				break;
			case PLATFORM_STATE.MOVING_TOWARDS:
				if (platformMoveX > 0) {
					if (this.transform.position.x <= (platformStartPosX + platformMoveX)) {
						this.transform.Translate (Vector3.right * platformSpeed * Time.deltaTime);
					} else
						completeX = true;
				} else
					completeX = true;
				if (platformMoveY > 0) {
					if (this.transform.position.y <= (platformStartPosY + platformMoveY)) {
						this.transform.Translate (Vector3.up * platformSpeed * Time.deltaTime);
					} else
						completeY = true;
				} else
					completeY = true;
				if (platformMoveZ > 0) {
					if (this.transform.position.z <= (platformStartPosZ + platformMoveZ)) {
						this.transform.Translate (Vector3.forward * platformSpeed * Time.deltaTime);
					} else
						completeZ = true;
				} else
					completeZ = true;
				if (completeX && completeY && completeZ) {
					completeX = completeY = completeZ = false;
					countdown = StartEndHoldTime;
					myPlatformState = PLATFORM_STATE.END;
				}
				break;
			case PLATFORM_STATE.END:
				if (countdown > 0) {
					countdown -= Time.deltaTime;
				} else
					myPlatformState = PLATFORM_STATE.MOVING_AWAY;
				break;
			case PLATFORM_STATE.MOVING_AWAY:
				if (platformMoveX > 0) {
					if (this.transform.position.x >= platformStartPosX) {
						this.transform.Translate (-Vector3.right * platformSpeed * Time.deltaTime);
					} else
						completeX = true;
				} else
					completeX = true;
				if (platformMoveY > 0) {
					if (this.transform.position.y >= platformStartPosY) {
						this.transform.Translate (-Vector3.up * platformSpeed * Time.deltaTime);
					} else
						completeY = true;
				} else
					completeY = true;
				if (platformMoveZ > 0) {
					if (this.transform.position.z >= platformStartPosZ) {
						this.transform.Translate (-Vector3.forward * platformSpeed * Time.deltaTime);
					} else
						completeZ = true;
				} else
					completeZ = true;
				if (completeX && completeY && completeZ) {
					completeX = completeY = completeZ = false;
					countdown = StartEndHoldTime;
					myPlatformState = PLATFORM_STATE.START;
				}
				break;
			}
		}
	}

}
