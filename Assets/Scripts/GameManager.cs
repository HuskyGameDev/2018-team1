using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player;

	private float defaultSpeed = 1f;

	// Use this for initialization
	void Start () {
		if (!PersistentData.ordinary) {
			PersistentData.upgrades.Add("MoveRight");
			PersistentData.upgrades.Add("Jump");
			PersistentData.upgrades.Add("MoveLeft");
			PersistentData.animator = "Animations/female-protag/Unarmed/Player";
			PersistentData.upgrades.Add("Crouch");
			//PersistentData.upgrades.Add("DoubleJump");
		}
		foreach (string s in PersistentData.upgrades) {
			AddUpgrade(s);
		}	
		player.GetComponent<Animator>().runtimeAnimatorController = 
			Resources.Load(PersistentData.animator) as RuntimeAnimatorController; 
	}

	public void AddUpgrade(string s) {
		if (s == "MoveLeft") 
			AddLeftMovement();
	 	else if (s == "MoveRight") 
			AddRightMovement();
		else if (s == "Jump") 
			AddJump();
		else if (s == "Dagger") 
			AddDagger();
		else if (s == "Crouch")
			AddCrouch();
		else if (s== "DoubleJump")
			AddDoubleJump();
	}
	private void AddLeftMovement() {
		MoveLeft comp = player.AddComponent<MoveLeft>() as MoveLeft;
		comp.SetSpeed(defaultSpeed);
	}
	private void AddRightMovement() {
		MoveRight comp = player.AddComponent<MoveRight>() as MoveRight;
		comp.SetSpeed(defaultSpeed);
	}
	private void AddJump() {
		Jump comp = player.AddComponent<Jump>() as Jump;
		comp.SetValues(4.5f, 6, 2, 4, 1 << LayerMask.NameToLayer("Ground"));
	}
	private void AddDagger() {
		GameObject attack = new GameObject();

		BoxCollider2D hitbox = attack.AddComponent<BoxCollider2D>() as BoxCollider2D;

		hitbox.isTrigger = true;
		hitbox.enabled = false;
		hitbox.size = new Vector2(.9f, .5f);
		hitbox.offset = new Vector2(.7f, 0);

		Hit hit = attack.AddComponent<Hit>() as Hit;
		hit.damage = 35;
		hit.knockback = 1000;

		attack.transform.SetParent(player.transform);
		attack.transform.localPosition = Vector3.zero;
		
		PlayerMelee pm = player.AddComponent<PlayerMelee>() as PlayerMelee;
		pm.meleeAttack = hitbox;
		pm.animator = player.GetComponent<Animator>();
	}
	private void AddCrouch() {
		player.AddComponent<Crouch>();
	}
	private void AddDoubleJump(){
		Jump j=player.GetComponent<Jump>();
		j.addDoubleJump();
	}
	private void RemoveUpgrades() {
		if (player.GetComponent<MoveLeft>() != null)
			Destroy(player.GetComponent<MoveLeft>());
		if (player.GetComponent<Jump>() != null)
			Destroy(player.GetComponent<Jump>());
		if (player.GetComponent<Crouch>() != null)
			Destroy(player.GetComponent<Crouch>());
		PersistentData.upgrades = new HashSet<string>();
		PersistentData.upgrades.Add("MoveRight");
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("v") && Input.GetKeyDown("b") && Input.GetKeyDown("n"))
				PersistentData.devMode = true;
		if (PersistentData.devMode) {
			if (Input.GetKeyDown(KeyCode.F1)) {
				RemoveUpgrades();
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/Peg-Patch/Player-PegPatch") as RuntimeAnimatorController;
			}
			if (Input.GetKeyDown(KeyCode.F2)) {
				RemoveUpgrades();
				AddLeftMovement();
				PersistentData.upgrades.Add("MoveLeft");
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/Peg/Peg") as RuntimeAnimatorController;
			}
			if (Input.GetKeyDown(KeyCode.F3)) {
				RemoveUpgrades();
				AddLeftMovement();
				AddJump();
				PersistentData.upgrades.Add("MoveLeft");
				PersistentData.upgrades.Add("Jump");
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/Unarmed/Player") as RuntimeAnimatorController;
			}
			if (Input.GetKeyDown(KeyCode.F4)) {
				RemoveUpgrades();
				AddLeftMovement();
				AddJump();
				AddDagger();
				PersistentData.upgrades.Add("MoveLeft");
				PersistentData.upgrades.Add("Jump");
				PersistentData.upgrades.Add("Dagger");
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/Dagger/Player-Dagger") as RuntimeAnimatorController;
			}
			if (Input.GetKeyDown(KeyCode.F8)) {
				PersistentData.ordinary = false;
				Start();
			}
			if (Input.GetKeyDown(KeyCode.F9)) {
				player.GetComponent<MoveRight>().speed = player.GetComponent<MoveRight>().speed * 2;
				player.GetComponent<MoveLeft>().speed = player.GetComponent<MoveLeft>().speed * 2;
			}
		}
	}
}
