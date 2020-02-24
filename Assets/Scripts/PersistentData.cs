using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public static class PersistentData {
	public static string lvlToLoad;
	public static bool firstRun = true;
	
	public static int UnlockData = 1; //int to be xor-ed for level loading
	public static int World1Levels = 0;
	public static int World2Levels = 0;
	public static int World3Levels = 0;
	public static int World4Levels = 0;

	public static HashSet<string> upgrades = new HashSet<string>();
	public static bool devMode;
	public static bool ordinary = false;
	public static string animator = "Animations/female-protag/Player-PegPatch";

	public static string lastScene = "";

	public static void changeScene(string lScene, string nScene) { //lastScene & nextScene
		lastScene = lScene;
		SceneManager.LoadScene(nScene);
	}
}
