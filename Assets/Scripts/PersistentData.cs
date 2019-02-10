using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Global {

	public static string lvlToLoad;
}

public class PersistentData : MonoBehaviour {
	public static List<string> upgrades = new List<string>();
	public static bool devMode;
	public static bool ordinary = false;
}
