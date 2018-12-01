using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public void LoadFlatland() {
        SceneManager.LoadScene("W1-4(F)");
    }
    public void LoadPlatform() {
        SceneManager.LoadScene("W1-1");
    }
    public void LoadOverworld() {
        SceneManager.LoadScene("Overworld");
    }
}
