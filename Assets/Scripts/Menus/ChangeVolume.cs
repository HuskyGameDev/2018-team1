using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{

	public Slider thisSlider;
	public int MasterVolume;
	public int EffectVolume;
	public int MusicVolume;

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
		int sliderValue = (int)thisSlider.value;

		if (whatValue == "MasterVolume")
		{
			//Debug.Log("changed master volume to :" + thisSlider.value);
			MasterVolume = (int)thisSlider.value;
			AkSoundEngine.SetRTPCValue("MasterVolume", MasterVolume);
		}

		if (whatValue == "EffectVolume")
		{
			//Debug.Log("changed master volume to :" + thisSlider.value);
			EffectVolume = (int)thisSlider.value;
			AkSoundEngine.SetRTPCValue("SFXVolume", EffectVolume);
		}

		if (whatValue == "MusicVolume")
		{
			//Debug.Log("changed master volume to :" + thisSlider.value);
			MusicVolume = (int)thisSlider.value;
			AkSoundEngine.SetRTPCValue("MusicVolume", MusicVolume);
		}
	}
}
