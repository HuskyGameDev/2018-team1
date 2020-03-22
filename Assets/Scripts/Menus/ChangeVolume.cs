using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{

	public Slider thisSlider
	public float masterVolume;
	public float sfxVolume;
	public float musicVolume;

	// Start is called before the first frame update
	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		
	}

	public void SetSpecificVolume(string whatValue)
	{
		float sliderValue = thisSlider.value;

		if (whatValue == "Master")
		{
			//Debug.Log("changed master volume to :" + thisSlider.value);
			masterVolume = thisSlider.value;
			AkSoundEngine.SetRTPCValue("MasterVolume", masterVolume);
		}

		if (whatValue == "Sounds")
		{
			//Debug.Log("changed master volume to :" + thisSlider.value);
			sfxVolume = thisSlider.value;
			AkSoundEngine.SetRTPCValue("SFXVolume", sfxVolume);
		}

		if (whatValue == "Music")
		{
			//Debug.Log("changed master volume to :" + thisSlider.value);
			musicVolume = thisSlider.value;
			AkSoundEngine.SetRTPCValue("MusicVolume", musicVolume);
		}
	}
}
