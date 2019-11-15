using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

	public bool gameIsPaused = false;

	public Transform player;
	public Transform cam;
	
	public GameObject pauseMenuUI;

	public Selectable PauseMenuStart;

	void Start() {
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update () {
		if (Sinput.GetButtonDown("Start"))
		{
			if (gameIsPaused)
			{
				resume();
			}
			else
			{
				pause();
			}
		}
		if (gameIsPaused && Sinput.GetButtonDown("Cancel"))
		{
			resume();
		}
	}

	public void resume()
	{
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		Cursor.visible = false;
		gameIsPaused = false;
	}

	void pause()
	{
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		Cursor.visible = true;
		gameIsPaused = true;
		PauseMenuStart.Select();
	}

	public void saveGame()
	{
		SaveLoad.Save();
		Debug.Log("Saving Game...");
	}

	public void reloadLevel()
	{
		resume();
		AkSoundEngine.StopAll();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
	}

	public void loadSave()
	{
		SaveLoad.Load();
		player.position = SaveLoad.saveGame.playerPosition;
		cam.position = SaveLoad.saveGame.cameraPosition;
		
		Debug.Log("Loading Save...");
	}

	public void loadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("MainMenu");
		
		Debug.Log("Loading Menu...");
	}

	public void loadOverworld()
	{
		LoadScene sceneLoader = new LoadScene();
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		gameIsPaused = false;
		sceneLoader.LoadOverworld();
	}

	public void quitGame()
	{
		Debug.Log("Quitting Game...");
		
		Application.Quit();
	}
}
