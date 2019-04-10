using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Global {

	public static string lvlToLoad;
	public static bool firstRun = true;

}

public class PersistentData : MonoBehaviour {
	public static HashSet<string> upgrades = new HashSet<string>();
	public static bool devMode;
	public static bool ordinary = false;
	public static string animator = "Animations/female-protag/Player-PegPatch";
}
