using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	//Ball Stats
	public int levelUnlock;
	public float ballAccel;
	public float ballMaxForwardVel;
	public float ballJump;

	//Game Settings
	public float MasterVolume;
	public float BackgroundVolume;
	public float SEVolume;
	public float VOVolume;

	//QuickSave / QuickLoad exact area position
	//QuickSave / QuickLoad are loacated in PlayerController script
	public int SceneID;
	public float PositionX, PositionY, PositionZ;
	public bool IsSceneBeingLoaded = false;

	void Awake()
	{
		if (control == null) 
		{
			DontDestroyOnLoad (gameObject);
			control = this;
		} 
		else if (control != this) 
		{
			Destroy (gameObject);
		}
	}

/*
	void OnGUI()
	{
		GUI.Label(new Rect(10,10,200,30), "Level: " + levelUnlock);
		GUI.Label (new Rect (10, 25, 200, 30), "SceneID: " + SceneID);
		GUI.Label (new Rect (10, 40, 200, 30), "POS X: " + PositionX);
		GUI.Label (new Rect (10, 55, 200, 30), "POS Y: " + PositionY);
		GUI.Label (new Rect (10, 70, 200, 30), "POS Z: " + PositionZ);
		GUI.Label(new Rect(10,85,200,30), "Accel: " + ballAccel);
		GUI.Label(new Rect(10,100,200,30), "MaxForwardVel: " + ballMaxForwardVel);
		GUI.Label(new Rect(10,115,200,30), "Jump: " + ballJump);
	}
*/	

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		//do before bf.Serialize
		PlayerData data = new PlayerData ();
		data.levelUnlock = levelUnlock;
		data.ballAccel = ballAccel;
		data.ballMaxForwardVel = ballMaxForwardVel;
		data.ballJump = ballJump;
		data.SceneID = SceneID;
		data.PositionX = PositionX;
		data.PositionY = PositionY;
		data.PositionZ = PositionZ;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load()
	{
		if (File.Exists (Application.persistentDataPath + "/playerInfo.dat")) 
		{
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			//do after file.Close();
			levelUnlock = data.levelUnlock;
			ballAccel = data.ballAccel;
			ballMaxForwardVel = data.ballMaxForwardVel;
			ballJump = data.ballJump;
			SceneID = data.SceneID;
			PositionX = data.PositionX;
			PositionY = data.PositionY;
			PositionZ = data.PositionZ;
		}
	}

}

[Serializable]
class PlayerData
{
	public int levelUnlock;
	public float ballAccel;
	public float ballMaxForwardVel;
	public float ballJump;

	public float MasterVolume;
	public float BackgroundVolume;
	public float SEVolume;
	public float VOVolume;

	public int SceneID;
	public float PositionX, PositionY, PositionZ;
}