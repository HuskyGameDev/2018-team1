using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public string level;
    public void LoadFlatland() {
        SceneManager.LoadScene("W1-4(F)");
    }
    public void LoadPlatform() {
        SceneManager.LoadScene("W1-1");
    }
    public void LoadOverworld() {
        string lev = SceneManager.GetActiveScene().name;
        lev = lev.Substring(1);
        Debug.Log("Level name: " + lev);
        Global.lvlToLoad = lev;
        SceneManager.LoadScene("Overworld");
    }
    public void LoadLevel() {
        if (level == "Overworld")
        {
            LoadOverworld();
        }
        else
        {
            SceneManager.LoadScene(level);
        }
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            LoadLevel();
    }
}
