using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class mainMenu : MonoBehaviour {

	public Selectable OptionsStartButton;
	public GameObject optionsMenu;

	private void Start() {
		Global.lvlToLoad = "1-1";
	}

	public void PlayGame()
	{
		SceneManager.LoadScene("W1-1");
		
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
