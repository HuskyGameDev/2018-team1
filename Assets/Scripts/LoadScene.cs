using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public string level;
    public int unlock;

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
        PersistentData.UnlockData ^= unlock;
        if (level == "Overworld")
        {
            int lev = convertToLevelID(SceneManager.GetActiveScene().name.Substring(3));
            switch ( SceneManager.GetActiveScene().name.Substring(1,1) )
            {
                case "1":
                    PersistentData.World1Levels |= lev;
                    break;
                case "2":
                    PersistentData.World2Levels |= lev;
                    break;
                case "3":
                    PersistentData.World3Levels |= lev;
                    break;
                case "4":
                    PersistentData.World4Levels |= lev;
                    break;
                default:
                    break;
            }
            LoadOverworld();
        }
        else
        {
            string lev = SceneManager.GetActiveScene().name;
            PersistentData.changeScene(lev, level);
        }
        
    }

    private static int convertToLevelID(string value)
    {
        if ( value == "F" || value == "F1")
        {
            return 256;
        }
        else if ( value == "F2" )
        {
            return 512;
        }
        int result = 0;
        for (int i = 0; i < value.Length; i++)
        {
            char letter = value[i];
            result = 10 * result + (letter - 48);
        }
        return (int)Math.Pow(2, result);
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
