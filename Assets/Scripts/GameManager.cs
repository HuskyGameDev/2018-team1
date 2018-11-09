using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		//Remove this and add these individually elsewhere
		PersistentData.upgrades = new string[] {"MoveLeft", "MoveRight", "Jump"};

		foreach (string s in PersistentData.upgrades) {
			if (s == "MoveLeft")  {
				MoveLeft comp = player.AddComponent<MoveLeft>() as MoveLeft;
				comp.SetSpeed(1);
			}
			else if (s == "MoveRight") {
				MoveRight comp = player.AddComponent<MoveRight>() as MoveRight;
				comp.SetSpeed(1);
			}
			else if (s == "Jump") {
				Jump comp = player.AddComponent<Jump>() as Jump;
				comp.SetValues(4.5f, 6, 1 << LayerMask.NameToLayer("Ground"));
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
