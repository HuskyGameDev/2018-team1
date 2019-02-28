using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PersistentData.upgrades.Add("MoveRight");
		PersistentData.ordinary = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
