using UnityEngine;
using System.Collections;

public class ButtonDoorController : MonoBehaviour {

//This script must be attached to a button. 
//When the button is collided with, the script will affect the gameobject door it is manually attached to.

	public GameObject door;

	[System.Serializable]
	public class DoorSettings
	{
        public bool isTrigger = false;
		public float doorMoveDistance = 10f;
		public float doorOpenSpeed = 1f;

		public bool timedDoor; //used if a door opens for only a limited amount of time
		public float openTime = 10f; //used for timed doors, how long door stays open
	}
	private float doorStartPosition; //x, y, or z, depending on door type
	private float countDown = 0f; //used for timed doors

	[System.Serializable]
	public class ButtonSettings
	{
		public float buttonMoveDistance = 4f;
		public float buttonRotation = 250f;

		public bool PlayerActivatedButton;
		public bool PickupActivatedButton;
		public bool BigPickupActivatedButton;
	}
	private float buttonStartPosition = 5f; //x, y, or z, depending on door type

	public DoorSettings doorSetting = new DoorSettings ();
	public ButtonSettings buttonSetting = new ButtonSettings ();

	public enum DOOR_DIRECTION
	{
		UP,
		DOWN,
		LEFT,
		RIGHT,
		FORWARD,
		BACKWARD,
        DISAPPEAR,
	}
	public DOOR_DIRECTION myDoorDirection = DOOR_DIRECTION.UP;

	private enum DOOR_STATE
	{
		CLOSED,
		OPENING,
		OPEN,
		CLOSING,
	}
	DOOR_STATE myDoorState = DOOR_STATE.CLOSED;

	public enum BUTTON_DIRECTION
	{
		UP,
		DOWN,
		LEFT,
		RIGHT,
		FORWARD,
		BACKWARD,
	}
	public BUTTON_DIRECTION myButtonDirection = BUTTON_DIRECTION.DOWN;


	private enum BUTTON_STATE
	{
		UNTOUCHED,
		SINKING,
		SUNK,
		RISING,
	}
	BUTTON_STATE myButtonState = BUTTON_STATE.UNTOUCHED;


	void Start()
	{
		switch (myButtonDirection) 
		{
		case BUTTON_DIRECTION.UP:
			buttonStartPosition = this.transform.position.y;
			break;
		case BUTTON_DIRECTION.DOWN:
			buttonStartPosition = this.transform.position.y;
			break;
		case BUTTON_DIRECTION.LEFT:
			buttonStartPosition = this.transform.position.x;
			break;
		case BUTTON_DIRECTION.RIGHT:
			buttonStartPosition = this.transform.position.x;
			break;
		case BUTTON_DIRECTION.FORWARD:
			buttonStartPosition = this.transform.position.z;
			break;
		case BUTTON_DIRECTION.BACKWARD:
			buttonStartPosition = this.transform.position.z;
			break;
		}
	}


	void Update () 
	{
		switch (myDoorState) 
		{
		case DOOR_STATE.CLOSED:
			break;
		case DOOR_STATE.OPENING:
			OpenDoor ();
			break;
		case DOOR_STATE.OPEN:
			if (doorSetting.timedDoor == true) 
			{
				CountDown ();
			}
			break;
		case DOOR_STATE.CLOSING:
			CloseDoor ();
			break;
		}


		switch (myButtonState) 
		{
		case BUTTON_STATE.UNTOUCHED:
			break;
		case BUTTON_STATE.SINKING:
			switch (myButtonDirection) 
			{
			case BUTTON_DIRECTION.UP:
				this.transform.Translate (Vector3.up * Time.deltaTime);
				this.transform.Rotate (Vector3.up, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.y >= (buttonStartPosition + buttonSetting.buttonMoveDistance)) 
				{
					myButtonState = BUTTON_STATE.SUNK;
				}
				break;
			case BUTTON_DIRECTION.DOWN:
				this.transform.Translate (Vector3.down * Time.deltaTime);
				this.transform.Rotate (Vector3.down, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.y <= (buttonStartPosition - buttonSetting.buttonMoveDistance)) 
				{
					myButtonState = BUTTON_STATE.SUNK;
				}
				break;
			case BUTTON_DIRECTION.LEFT:
				this.transform.Translate (Vector3.left * Time.deltaTime);
				this.transform.Rotate (Vector3.left, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.x <= (buttonStartPosition - buttonSetting.buttonMoveDistance)) 
				{
					myButtonState = BUTTON_STATE.SUNK;
				}
				break;
			case BUTTON_DIRECTION.RIGHT:
				this.transform.Translate (Vector3.right * Time.deltaTime);
				this.transform.Rotate (Vector3.right, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.x >= (buttonStartPosition + buttonSetting.buttonMoveDistance)) 
				{
					myButtonState = BUTTON_STATE.SUNK;
				}
				break;
			case BUTTON_DIRECTION.FORWARD:
				this.transform.Translate (Vector3.forward * Time.deltaTime);
				this.transform.Rotate (Vector3.forward, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.z >= (buttonStartPosition + buttonSetting.buttonMoveDistance)) 
				{
					myButtonState = BUTTON_STATE.SUNK;
				}
				break;
			case BUTTON_DIRECTION.BACKWARD:
				this.transform.Translate (Vector3.back * Time.deltaTime);
				this.transform.Rotate (Vector3.back, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.z <= (buttonStartPosition - buttonSetting.buttonMoveDistance)) 
				{
					myButtonState = BUTTON_STATE.SUNK;
				}
				break;
			}
			break;
		case BUTTON_STATE.SUNK:
			break;
		case BUTTON_STATE.RISING: //opposite of SINKING
			switch (myButtonDirection) 
			{
			case BUTTON_DIRECTION.UP:
				this.transform.Translate (-Vector3.up * Time.deltaTime);
				this.transform.Rotate (-Vector3.up, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.y <= buttonStartPosition) 
				{
					myButtonState = BUTTON_STATE.UNTOUCHED;
				}
				break;
			case BUTTON_DIRECTION.DOWN:
				this.transform.Translate (-Vector3.down * Time.deltaTime);
				this.transform.Rotate (-Vector3.down, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.y >= buttonStartPosition) 
				{
					myButtonState = BUTTON_STATE.UNTOUCHED;
				}
				break;
			case BUTTON_DIRECTION.LEFT:
				this.transform.Translate (-Vector3.left * Time.deltaTime);
				this.transform.Rotate (-Vector3.left, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.x >= buttonStartPosition) 
				{
					myButtonState = BUTTON_STATE.UNTOUCHED;
				}
				break;
			case BUTTON_DIRECTION.RIGHT:
				this.transform.Translate (-Vector3.right * Time.deltaTime);
				this.transform.Rotate (-Vector3.right, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.x <= buttonStartPosition) 
				{
					myButtonState = BUTTON_STATE.UNTOUCHED;
				}
				break;
			case BUTTON_DIRECTION.FORWARD:
				this.transform.Translate (-Vector3.forward * Time.deltaTime);
				this.transform.Rotate (-Vector3.forward, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.z <= buttonStartPosition) 
				{
					myButtonState = BUTTON_STATE.UNTOUCHED;
				}
				break;
			case BUTTON_DIRECTION.BACKWARD:
				this.transform.Translate (-Vector3.back * Time.deltaTime);
				this.transform.Rotate (-Vector3.back, buttonSetting.buttonRotation * Time.deltaTime);
				if (this.transform.position.z >= buttonStartPosition) 
				{
					myButtonState = BUTTON_STATE.UNTOUCHED;
				}
				break;
			}
			break;
		}
			
	} //end of Update()


	void OnCollisionEnter (Collision collision)
	{
		switch (myButtonState) 
		{
		//button usable only when untouched
		//maybe add in ability to work while rising, but needs 
		//to change the "door original position" updating when door opens
		//otherwise, door will have a new starting position
		//could be feature: Puzzles? 
		//but also problems with any door locking after time
		//after all, don't want unexpected behavior
		case BUTTON_STATE.UNTOUCHED:
			switch (collision.transform.tag) 
			{
			case "Player":
				if (buttonSetting.PlayerActivatedButton == true)
					DoorOpenFunctions ();
				break;
			case "Pickup":
				if (buttonSetting.PickupActivatedButton == true)
					DoorOpenFunctions ();
				break;
			case "BigPickup":
				if (buttonSetting.BigPickupActivatedButton == true)
					DoorOpenFunctions ();
				break;
			}
			break;
		case BUTTON_STATE.SINKING:
			break;
		case BUTTON_STATE.SUNK:
			break;
		case BUTTON_STATE.RISING:
			break;
		}
	}

    void OnTriggerEnter(Collider collision)
    {
        switch (myButtonState)
        {
            //button usable only when untouched
            //maybe add in ability to work while rising, but needs 
            //to change the "door original position" updating when door opens
            //otherwise, door will have a new starting position
            //could be feature: Puzzles? 
            //but also problems with any door locking after time
            //after all, don't want unexpected behavior
            case BUTTON_STATE.UNTOUCHED:
                switch (collision.transform.tag)
                {
                    case "Player":
                        if (buttonSetting.PlayerActivatedButton == true)
                            DoorOpenFunctions();
                        break;
                    case "Pickup":
                        if (buttonSetting.PickupActivatedButton == true)
                            DoorOpenFunctions();
                        break;
                    case "BigPickup":
                        if (buttonSetting.BigPickupActivatedButton == true)
                            DoorOpenFunctions();
                        break;
                }
                break;
            case BUTTON_STATE.SINKING:
                break;
            case BUTTON_STATE.SUNK:
                break;
            case BUTTON_STATE.RISING:
                break;
        }
    }

    void DoorOpenFunctions()
	{
		switch (myDoorDirection) 
		{
            case DOOR_DIRECTION.UP:
                doorStartPosition = door.transform.position.y;
                break;
		    case DOOR_DIRECTION.DOWN:
			    doorStartPosition = door.transform.position.y;
		    	break;
    		case DOOR_DIRECTION.LEFT:
	    		doorStartPosition = door.transform.position.x;
		    	break;
    		case DOOR_DIRECTION.RIGHT:
	    		doorStartPosition = door.transform.position.x;
		    	break;
    		case DOOR_DIRECTION.FORWARD:
	    		doorStartPosition = door.transform.position.z;
		    	break;
            case DOOR_DIRECTION.BACKWARD:
	    		doorStartPosition = door.transform.position.z;
		    	break;
            case DOOR_DIRECTION.DISAPPEAR:
                door.SetActive(true);
                break;
		} 

		myDoorState = DOOR_STATE.OPENING;
		myButtonState = BUTTON_STATE.SINKING;

		if (doorSetting.timedDoor == true) 
		{
			countDown = doorSetting.openTime;
		}
	}


	void OpenDoor()
	{
		switch (myDoorDirection) 
		{
	    	case DOOR_DIRECTION.UP:
		    	door.transform.Translate (Vector3.up * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
			    if (door.transform.position.y >= (doorStartPosition + doorSetting.doorMoveDistance)) 
    			{
                    Open();
                }
			    break;
    		case DOOR_DIRECTION.DOWN:
	    		door.transform.Translate (Vector3.down * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
		    	if (door.transform.position.y <= (doorStartPosition - doorSetting.doorMoveDistance)) 
			    {
                    Open();
                }
	    		break;
    		case DOOR_DIRECTION.LEFT:
	    		door.transform.Translate (Vector3.left * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
		    	if (door.transform.position.x <= (doorStartPosition - doorSetting.doorMoveDistance)) 
    			{
                    Open();
                }
			    break;
    		case DOOR_DIRECTION.RIGHT:
	    		door.transform.Translate (Vector3.right * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
		    	if (door.transform.position.x >= (doorStartPosition + doorSetting.doorMoveDistance)) 
			    {
                    Open();
                }
	    		break;
	    	case DOOR_DIRECTION.FORWARD:
		    	door.transform.Translate (Vector3.forward * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
			    if (door.transform.position.z >= (doorStartPosition + doorSetting.doorMoveDistance)) 
			    {
                    Open();
                }
			    break;
    		case DOOR_DIRECTION.BACKWARD:
	    		door.transform.Translate (Vector3.back * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
		    	if (door.transform.position.z <= (doorStartPosition - doorSetting.doorMoveDistance)) 
			    {
                    Open();
                }
			    break;
            case DOOR_DIRECTION.DISAPPEAR:
                StartCoroutine(Disappearing());
                Open();
                break;
		}
	}

    void Open()
    {
        myDoorState = DOOR_STATE.OPEN;
    }

    IEnumerator Disappearing()
    {
        yield return new WaitForSeconds(0.2f);
        door.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        door.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        door.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        door.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        door.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        door.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        door.SetActive(false);

    }

    void CountDown()
	{
		countDown -= Time.deltaTime;

		//if countdown ends, door and button reset positions
		if (countDown <= 0)
		{
			myDoorState = DOOR_STATE.CLOSING;
			myButtonState = BUTTON_STATE.RISING;
		}
	}


	void CloseDoor()
	{
		switch (myDoorDirection) 
		{
    		case DOOR_DIRECTION.UP:
	    		door.transform.Translate (-Vector3.up * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
		    	if (door.transform.position.y <= doorStartPosition) 
			    {
                    Close();
                }
	    		break;
    		case DOOR_DIRECTION.DOWN:
	    		door.transform.Translate (-Vector3.down * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
		    	if (door.transform.position.y >= doorStartPosition) 
			    {
                    Close();
                }
			    break;
    		case DOOR_DIRECTION.LEFT:
	    		door.transform.Translate (-Vector3.left * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
		    	if (door.transform.position.x >= doorStartPosition) 
			    {
                    Close();
                }
    			break;
	    	case DOOR_DIRECTION.RIGHT:
		    	door.transform.Translate (-Vector3.right * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
			    if (door.transform.position.x <= doorStartPosition) 
			    {
                    Close();
                }
			    break;
    		case DOOR_DIRECTION.FORWARD:
	    		door.transform.Translate (-Vector3.forward * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
		    	if (door.transform.position.z <= doorStartPosition) 
			    {
                    Close();
                }
	    		break;
    		case DOOR_DIRECTION.BACKWARD:
	    		door.transform.Translate (-Vector3.back * doorSetting.doorOpenSpeed * Time.deltaTime * 3);
		    	if (door.transform.position.z >= doorStartPosition) 
			    {
                    Close();
			    }
			    break;
            case DOOR_DIRECTION.DISAPPEAR:
                door.SetActive(true);
                Close();
                break;
        }
	}

    void Close()
    {
        myDoorState = DOOR_STATE.CLOSED;
    }
}
