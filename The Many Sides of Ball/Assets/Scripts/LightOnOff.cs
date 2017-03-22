using UnityEngine;
using System.Collections;

public class LightOnOff : MonoBehaviour {

	private Light light;
	public float offTime;
	public float onTime;
	public float turnOnDelay;

	private float startingOffTime;
	private float startingOnTime;

	private enum LIGHT_STATE
	{
		DELAYED,
		OFF,
		ON,
	}
	LIGHT_STATE myLightState = LIGHT_STATE.ON;

	void Start ()
	{
		light = this.GetComponent<Light> ();

		startingOffTime = offTime;
		startingOnTime = onTime;
		if (turnOnDelay > 0) 
		{
			myLightState = LIGHT_STATE.DELAYED;
		}
	}

	void Update () 
	{
		switch (myLightState) 
		{
		case LIGHT_STATE.ON:
			onTime -= Time.deltaTime;
			if (onTime <= 0) 
			{
				TurnOff ();	
			}
			break;
		case LIGHT_STATE.OFF:
			offTime -= Time.deltaTime;
			if (offTime <= 0) 
			{
				TurnOn ();	
			}
			break;
		case LIGHT_STATE.DELAYED:
			turnOnDelay -= Time.deltaTime;
			if (turnOnDelay <= 0) 
			{
				TurnOn ();	
			}
			break;
		}
		/*
		if (isOn == true) 
		{
			onTime -= Time.deltaTime;
			if (onTime <= 0) 
			{
				TurnOff ();	
			}
		} 
		else if (turnOnDelay > 0)
		{
			turnOnDelay -= Time.deltaTime;
			if (turnOnDelay <= 0) 
			{
				TurnOn ();	
			}
		}
		else
		{
			offTime -= Time.deltaTime;
			if (offTime <= 0) 
			{
				TurnOn ();	
			}
		}*/
	}

	void TurnOn()
	{
		myLightState = LIGHT_STATE.ON;		
		light.enabled = true;
		offTime = startingOffTime;
	}

	void TurnOff()
	{
		myLightState = LIGHT_STATE.OFF;
		light.enabled = false;
		onTime = startingOnTime;
	}
}
