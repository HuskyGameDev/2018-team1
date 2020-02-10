using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public string level;

    public void LoadFlatland() {
        string lev = SceneManager.GetActiveScene().name;
        PersistentData.changeScene(lev, "W1-4(F)");
    }

    public void LoadPlatform() {
        string lev = SceneManager.GetActiveScene().name;
        PersistentData.changeScene(lev, "W1-1");
    }

    public void LoadOverworld() {
        string lev = SceneManager.GetActiveScene().name;
        lev = lev.Substring(1);
        Debug.Log("Level name: " + lev);
        PersistentData.lvlToLoad = lev;
        PersistentData.changeScene(lev, "Overworld");
    }

    public void LoadLevel() {
        if (level == "Overworld")
        {
            LoadOverworld();
        }
        else
        {
            string lev = SceneManager.GetActiveScene().name;
            PersistentData.changeScene(lev, level);
        }
        
    }

    public void LoadMenuFromControls() {
        string cont = SceneManager.GetActiveScene().name;
        PersistentData.changeScene(cont, "StartMenu");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
            LoadLevel();
    }
}
