using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
		if (!PersistentData.ordinary) {
			PersistentData.upgrades.Add("MoveLeft");
			PersistentData.upgrades.Add("MoveRight");
			PersistentData.upgrades.Add("Jump");
		}
		foreach (string s in PersistentData.upgrades) {
			AddUpgrade(s);
		}	
	}

	public void AddUpgrade(string s) {
		if (s == "MoveLeft")  {
			MoveLeft comp = player.AddComponent<MoveLeft>() as MoveLeft;
			comp.SetSpeed(1);
		} else if (s == "MoveRight") {
			MoveRight comp = player.AddComponent<MoveRight>() as MoveRight;
			comp.SetSpeed(1);
		} else if (s == "Jump") {
			Jump comp = player.AddComponent<Jump>() as Jump;
			comp.SetValues(4.5f, 6, 1 << LayerMask.NameToLayer("Ground"));
		}
		else if (s == "Dagger") {
			GameObject attack = new GameObject();

			BoxCollider2D hitbox = attack.AddComponent<BoxCollider2D>() as BoxCollider2D;

			hitbox.isTrigger = true;
			hitbox.enabled = false;
			hitbox.size = new Vector2(.9f, .5f);
			hitbox.offset = new Vector2(.7f, 0);

			Hit hit = attack.AddComponent<Hit>() as Hit;
			hit.damage = 20;
			hit.knockback = 1000;

			attack.transform.SetParent(player.transform, false);
			attack.transform.position = Vector3.zero;
			attack.transform.position = Vector3.zero;
			attack.transform.position = Vector3.zero;
			attack.transform.position = Vector3.zero;
			attack.transform.position = Vector3.zero;
			attack.transform.position = Vector3.zero;
			attack.transform.position = Vector3.zero;
			attack.transform.position = Vector3.zero;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("v") && Input.GetKeyDown("b") && Input.GetKeyDown("n"))
				PersistentData.devMode = true;
		if (PersistentData.devMode) {
			if (Input.GetKeyDown(KeyCode.F8)) {
				PersistentData.upgrades.Add("MoveLeft");
				PersistentData.upgrades.Add("MoveRight");
				PersistentData.upgrades.Add("Jump");
				foreach (string s in PersistentData.upgrades) 
					AddUpgrade(s);
			}
			if (Input.GetKeyDown(KeyCode.F9)) {
				player.GetComponent<MoveRight>().speed = player.GetComponent<MoveRight>().speed * 2;
				player.GetComponent<MoveLeft>().speed = player.GetComponent<MoveLeft>().speed * 2;
			}
		}
	}
}
