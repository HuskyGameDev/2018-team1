using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public static class Global {

	public static string lvlToLoad;
	public static bool firstRun = true;

}

public class PersistentData : MonoBehaviour {
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
