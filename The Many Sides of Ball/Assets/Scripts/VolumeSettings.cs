using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour {

	public AudioMixer masterMixer;
//	public Slider slider;

	public void ChangeMasterVolume (float masterVol) 
	{
		masterMixer.SetFloat("masterVol", masterVol);
	}

	public void ChangeBackgroundVolume (float backgroundVol) 
	{
		masterMixer.SetFloat("backgroundVol", backgroundVol);
	}

	public void ChangeSEVolume (float seVol) 
	{
		masterMixer.SetFloat("seVol", seVol);
	}

	public void ChangeVOVolume (float voVol) 
	{
		masterMixer.SetFloat("voVol", voVol);
	}
}
