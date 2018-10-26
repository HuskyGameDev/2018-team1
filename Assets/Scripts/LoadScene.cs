using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public void LoadFlatland() {
        PersistentData.level = "Flatland";
        SceneManager.LoadScene("Level");
    }
    public void LoadPlatform() {
        PersistentData.level = "Platform";
        SceneManager.LoadScene("Level");
    }
    public void LoadOverworld() {
        SceneManager.LoadScene("Overworld");
    }
}
