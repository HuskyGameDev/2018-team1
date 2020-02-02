using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mainMenu : MonoBehaviour {

	public Selectable OptionsStartButton;
	public Selectable OptionsControlsButton;
	public GameObject optionsMenu;

	public Selectable continueButton;
	public Selectable newGame;
	public Selectable quitGame;

	public saveLoad saveLoad;

	private void Start() {
		PersistentData.lvlToLoad = "1-1";
		if(File.Exists(Application.persistentDataPath + "/save.pkr"))
		{
			continueButton.gameObject.SetActive(true);
			continueButton.Select();

			Navigation quitNav = quitGame.navigation;
			quitNav.selectOnDown = continueButton;
			quitGame.navigation = quitNav;

			Navigation newNav = newGame.navigation;
			newNav.selectOnUp = continueButton;
			newGame.navigation = newNav;
		}
		else
		{
			continueButton.gameObject.SetActive(true);
			continueButton.interactable = false;
		}
		if ( PersistentData.lastScene == "SinputRebind")
		{
			this.gameObject.SetActive(false);
			optionsMenu.SetActive(true);
			OptionsControlsButton.Select();
		}
		Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, Screen.fullScreenMode, 60);
		Screen.fullScreen = true;
		
	}

	public void PlayGame()
	{
		PersistentData.changeScene("MainMenu", "W1-1");
	}

	public void ContinueGame()
	{
		//TODO:go to map method with a way to trigger load game
		PersistentData.changeScene("MainMenu", "Overworld");
	}
	public void OptionsMenu()
	{
		this.gameObject.SetActive(false);
		optionsMenu.SetActive(true);
		OptionsStartButton.Select();
	}

	public void QuitGame()
	{
		Debug.Log("Quitting Game...");
		Application.Quit();
	}

}
