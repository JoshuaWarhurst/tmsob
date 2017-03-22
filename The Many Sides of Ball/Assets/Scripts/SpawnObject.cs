using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	private bool inRange = false;

	void Awake ()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				if (inRange) 
				{
					Vector3 spawnPosition = new Vector3 (Random.Range(spawnValues.x-2f, spawnValues.x+2f), spawnValues.y, Random.Range(spawnValues.z - 2f, spawnValues.z + 2f));
					Quaternion spawnRotation = Quaternion.identity;
					Instantiate (hazard, spawnPosition, spawnRotation);
				}
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

	void OnTriggerStay()
	{
		inRange = true;
	}

	void OnTriggerExit ()
	{
		inRange = false;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube (new Vector3 (spawnValues.x, spawnValues.y, spawnValues.z), this.transform.localScale);
	}
}