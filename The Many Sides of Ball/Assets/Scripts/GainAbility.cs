using UnityEngine;
using System.Collections;

public class GainAbility : MonoBehaviour {

	public enum ABILITY
	{
		NONE,
		FLOAT,
		PICKUP_SMALL,
		PICKUP_BIG,
		SPEED_BOOST,
		COLOR_SHIFT_BLUE,
		COLOR_SHIFT_YELLOW,
	}

	public ABILITY gainAbility = ABILITY.NONE;

	private PlayerController player;

	void Start ()
	{
		player = GameObject.Find ("Player").GetComponent<PlayerController> ();
	}
		
	void OnTriggerEnter (Collider collision)
	{
		if (collision.transform.tag == "Player") 
		{
			switch (gainAbility) 
			{
			case ABILITY.NONE:
				break;
			case ABILITY.FLOAT:
				player.abilitySetting.ableToFloat = true;
				break;
			case ABILITY.PICKUP_SMALL:
				player.abilitySetting.ableToLiftSmall = true;
				break;
			case ABILITY.PICKUP_BIG:
				player.abilitySetting.ableToLiftBig = true;
				break;
			case ABILITY.SPEED_BOOST:
				player.abilitySetting.ableToSpeedBoost = true;
				break;
			case ABILITY.COLOR_SHIFT_BLUE:
				break;
			case ABILITY.COLOR_SHIFT_YELLOW:
				break;
			}
			Destroy (gameObject);
		}
	}
}
