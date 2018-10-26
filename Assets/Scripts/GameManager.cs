using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		foreach (string s in PersistentData.upgrades)
			player.AddComponent<GameManager>(); //Load the individual upgrades
		if (PersistentData.level.Equals("Flatland")) {
			//Load the enemies/allies
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
