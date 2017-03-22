using UnityEngine;
using System.Collections;

public class BasicObjectScaling : MonoBehaviour {

	public float scaleUpRate = 0.1f;
	public float scaleDownRate = 0.1f;

	public float startXScale = 1f;
	public float startYScale = 1f;
	public float startZScale = 1f;
	public float endXScale = 2f;
	public float endYScale = 2f;
	public float endZScale = 2f;

	private int allDone = 0;

	private enum CURRENT_SIZE
	{
		BECOME_BIGGER,
		BECOME_SMALLER,
	}

	private CURRENT_SIZE myCurrentSize = CURRENT_SIZE.BECOME_BIGGER;

	void Update () 
	{
		switch (myCurrentSize) 
		{
		case CURRENT_SIZE.BECOME_BIGGER:
			if (transform.localScale.x <= endXScale) 
			{
				transform.localScale += new Vector3 (1,0,0) * scaleUpRate * Time.deltaTime;	
			} 
			if (transform.localScale.y <= endYScale) 
			{
				transform.localScale += new Vector3 (0,1,0) * scaleUpRate * Time.deltaTime;	
			} 
			if (transform.localScale.z <= endZScale) 
			{
				transform.localScale += new Vector3 (0,0,1) * scaleUpRate * Time.deltaTime;	
			} 
			else 
			{
				myCurrentSize = CURRENT_SIZE.BECOME_SMALLER;
			}
			break;
		case CURRENT_SIZE.BECOME_SMALLER:
			if (transform.localScale.x >= startXScale) 
			{
				transform.localScale -= new Vector3 (1,0,0) * scaleDownRate * Time.deltaTime;	
			} 
			if (transform.localScale.y >= startYScale) 
			{
				transform.localScale -= new Vector3 (0,1,0) * scaleDownRate * Time.deltaTime;	
			} 
			if (transform.localScale.z >= startZScale) 
			{
				transform.localScale -= new Vector3 (0,0,1) * scaleDownRate * Time.deltaTime;	
			} 
			else 
			{
				myCurrentSize = CURRENT_SIZE.BECOME_BIGGER;
			}
			break;
		}
	}
}
