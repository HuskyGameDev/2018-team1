using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
 
 // referenced this guide on how to make a save/load script: https://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934
public class SaveLoad : MonoBehaviour {
 
    public Game saveGame;

    void Start()
    {
        saveGame = new Game();
    }
             
    //it's static so we can call it from anywhere
    public void Save(Vector3 playerPos, Vector3 cameraPos, string levelName) {
        saveGame.upgrades = new List<string>(PersistentData.upgrades);
        saveGame.playerPosition.V3 = playerPos;
        saveGame.cameraPosition.V3 = cameraPos;
        saveGame.levelName = levelName;
        saveGame.lastScene = PersistentData.lastScene;
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create (Application.persistentDataPath + "/save.pkr"); //you can call it anything you want
        Debug.Log("filepath to game data: " + Application.persistentDataPath);
        bf.Serialize(file, saveGame);
        file.Close();
    }   

    public void Load() {
        Debug.Log("filepath to game data: " + Application.persistentDataPath);
        if(File.Exists(Application.persistentDataPath + "/save.pkr")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.pkr", FileMode.Open);
            saveGame = (Game)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log("Savefile does not exist.");
        }
    }
}

[System.Serializable]
public class Vector3Serializer
{
    public float x;
    public float y;
    public float z;
 
    public void Fill(Vector3 v3)
    {
        x = v3.x;
        y = v3.y;
        z = v3.z;
    }
 
    public Vector3 V3 { get { return new Vector3(x, y, z); } set { Fill(value); } }
 
}

[System.Serializable]
public class Game
{
    public Vector3Serializer playerPosition;
    public Vector3Serializer cameraPosition;
    public List<string> upgrades;

    public string levelName;
    public string lastScene;

    public Game()
    {
        playerPosition = new Vector3Serializer();
        cameraPosition = new Vector3Serializer();
        upgrades = null;
        levelName = "";
        lastScene = "";
    }
}