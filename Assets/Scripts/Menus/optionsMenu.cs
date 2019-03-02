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

	public void toVideo()
	{
		this.transform.Find("MainOptions").gameObject.SetActive(false);
		this.transform.Find("VideoOptions").gameObject.SetActive(true);
	}

	public void fromVideo()
	{
		this.transform.Find("VideoOptions").gameObject.SetActive(false);
		this.transform.Find("MainOptions").gameObject.SetActive(true);
	}

	public void toVolume()
	{
		this.transform.Find("MainOptions").gameObject.SetActive(false);
		this.transform.Find("VolumeOptions").gameObject.SetActive(true);
	}

	public void fromVolume()
	{
		this.transform.Find("VolumeOptions").gameObject.SetActive(false);
		this.transform.Find("MainOptions").gameObject.SetActive(true);
	}

	public void toControls()
	{
		this.transform.Find("MainOptions").gameObject.SetActive(false);
		this.transform.Find("Controls").gameObject.SetActive(true);
	}

	public void fromControls()
	{
		this.transform.Find("Controls").gameObject.SetActive(false);
		this.transform.Find("MainOptions").gameObject.SetActive(true);
	}
}
