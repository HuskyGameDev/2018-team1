using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;

public class optionsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public Dropdown resolutionDropdown;

	Resolution[] resolutions;

	public GameObject backTarget;
	public Selectable MainVideoSelectable;
	public Selectable MainVolumeSelectable;
	public Selectable MainControlsSelectable;
	public Selectable VideoOptionsSelectable;
	public Selectable VolumeOptionsSelectable;
	public Selectable ControlsOptionsSelectable;
	public Selectable MainMenuSelectable;

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

	void Update() {
		if (Sinput.GetButtonDown("Cancel"))
		{
			if (this.transform.Find("VideoOptions").gameObject.activeSelf)
			{
				fromVideo();
			}
			else if (this.transform.Find("VolumeOptions").gameObject.activeSelf)
			{
				fromVolume();
			}
			else if (this.transform.Find("Controls").gameObject.activeSelf)
			{
				fromControls();
			}
			else
			{
				Back();
			}
		}
	}

	public void Back()
	{
		this.gameObject.SetActive(false);
		backTarget.SetActive(true);
		MainMenuSelectable.Select();
	}

	public void toVideo()
	{
		this.transform.Find("MainOptions").gameObject.SetActive(false);
		this.transform.Find("VideoOptions").gameObject.SetActive(true);
		VideoOptionsSelectable.Select();
	}

	public void fromVideo()
	{
		this.transform.Find("VideoOptions").gameObject.SetActive(false);
		this.transform.Find("MainOptions").gameObject.SetActive(true);
		MainVideoSelectable.Select();
	}

	public void toVolume()
	{
		this.transform.Find("MainOptions").gameObject.SetActive(false);
		this.transform.Find("VolumeOptions").gameObject.SetActive(true);
		VolumeOptionsSelectable.Select();
	}

	public void fromVolume()
	{
		this.transform.Find("VolumeOptions").gameObject.SetActive(false);
		this.transform.Find("MainOptions").gameObject.SetActive(true);
		MainVolumeSelectable.Select();
	}

	public void toControls()
	{
		this.transform.Find("MainOptions").gameObject.SetActive(false);
		this.transform.Find("Controls").gameObject.SetActive(true);
		ControlsOptionsSelectable.Select();
	}

	public void fromControls()
	{
		this.transform.Find("Controls").gameObject.SetActive(false);
		this.transform.Find("MainOptions").gameObject.SetActive(true);
		MainControlsSelectable.Select();
	}
}
