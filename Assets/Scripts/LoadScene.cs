using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public void LoadFlatland() {
        SceneManager.LoadScene("Level");
    }
    public void LoadPlatform() {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadOverworld() {
        SceneManager.LoadScene("Overworld");
    }
}
