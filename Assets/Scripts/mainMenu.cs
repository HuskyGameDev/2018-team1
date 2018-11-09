using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {

	public GameObject optionsMenu;

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void OptionsMenu()
	{
		this.gameObject.SetActive(false);
		optionsMenu.SetActive(true);

	}

	public void QuitGame()
	{
		Debug.Log("Quitting Game...");
		Application.Quit();
	}

}
