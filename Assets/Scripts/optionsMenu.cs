using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class optionsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public Dropdown resolutionDropdown;

	Resolution[] resolutions;

	public GameObject backTarget;

	// Use this for initialization
	void Start () {
		resolutions = Screen.resolutions;
		resolutionDropdown.ClearOptions();
		List<string> options = new List<string>();
		for ( int i = 0; i < resolutions.Length; i++ )
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);
		}

		resolutionDropdown.AddOptions(options);
	}

	public void Back()
	{
		this.gameObject.SetActive(false);
		backTarget.SetActive(true);
	}
}
