using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class optionsMenu : MonoBehaviour {

	public AudioMixer audioMixer;

	public Dropdown resolutionDropdown;
	public Toggle fullScreenToggle;

	public GameObject backTarget;
	public Selectable MainVideoSelectable;
	public Selectable MainVolumeSelectable;
	public Selectable MainControlsSelectable;
	public Selectable VideoOptionsSelectable;
	public Selectable VolumeOptionsSelectable;
	public Selectable ControlsOptionsSelectable;
	public Selectable MainMenuSelectable;

	public Image image1;

	protected List<string> options;

	// Use this for initialization
	void Start () {
		resolutionDropdown.ClearOptions();
		options = new List<string>();

		Resolution[] resolutionList = Screen.resolutions;

		foreach (Resolution r in resolutionList)
		{
			if ( r.width >= 1280 && r.height == 720 )
			{
				options.Add("1280x720");
			}
			else if ( r.width >= 1366 && r.height == 768 )
			{
				options.Add("1366x768");
			}
			else if ( r.width >= 1600 && r.height == 900 )
			{
				options.Add("1600x900");
			}
			else if ( r.width >= 1920 && r.height == 1080 )
			{
				options.Add("1920x1080");
			}
			else if ( r.width >= 2560 && r.height == 1440 )
			{
				options.Add("2560x1440");
			}
			else if ( r.width >= 3840 && r.height == 2160 )
			{
				options.Add("3840x2160");
			}
		}

		//prevents duplicate resolutions
		HashSet<string> noDupes = new HashSet<string>(options);
		options.Clear();
		options.AddRange(noDupes);

		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = options.Count - 1;
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
		image1.enabled = true;
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
		setScreen();
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
		PersistentData.changeScene(SceneManager.GetActiveScene().name, "SinputRebind");
	}

	public void setScreen()
	{
		string currentRes = options[resolutionDropdown.value];
		string[] resParts = currentRes.Split('x');
		int x = System.Convert.ToInt32(resParts[0]);
		int y = System.Convert.ToInt32(resParts[1]);
		Screen.SetResolution(x, y, Screen.fullScreenMode, 60);
		Screen.fullScreen = fullScreenToggle.isOn;
	}
}
