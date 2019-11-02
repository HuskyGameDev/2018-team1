using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
 
 // referenced this guide on how to make a save/load script: https://gamedevelopment.tutsplus.com/tutorials/how-to-save-and-load-your-players-progress-in-unity--cms-20934
public static class SaveLoad {
 
    public static Game saveGame = new Game();
             
    //it's static so we can call it from anywhere
    public static void Save(Vector3 playerPos, Vector3 cameraPos) {
        saveGame = Game.Instance;
        saveGame.upgrades = PersistentData.upgrades;
        saveGame.playerPosition = playerPos;
        saveGame.cameraPosition = cameraPos;
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create (Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
        Debug.Log("filepath to game data: " + Application.persistentDataPath);
        bf.Serialize(file, SaveLoad.saveGame);
        file.Close();
    }   

    /**TODO:
     * return 2 Vector3s for restoring the playerPosition & cameraPosition
     */
    public static void Load(Vector3 playerPos, Vector3 cameraPos, out Vector3 outPlayerPos, out Vector3 outCameraPos) {
        outPlayerPos = playerPos;
        outCameraPos = cameraPos;
        if(File.Exists(Application.persistentDataPath + "/savedGames.gd")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            saveGame = (Game)bf.Deserialize(file);
            file.Close();
            PersistentData.upgrades = saveGame.upgrades;
            outCameraPos = saveGame.cameraPosition;
            outPlayerPos = saveGame.playerPosition;
        }
    }
}

[System.Serializable]
public class Game
{
    public Vector3 playerPosition;
    public Vector3 cameraPosition;
    public HashSet<string> upgrades;

    public static Game Instance;

}