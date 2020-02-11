using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameManager : MonoBehaviour {

	public GameObject player;

	public float defaultSpeed = 1f;

	// Use this for initialization
	void Start () {
		foreach (string s in PersistentData.upgrades) {
			AddUpgrade(s);
		}
		if (!PersistentData.ordinary) {
			PlayerState5();
			PersistentData.animator = "Animations/female-protag/PistolAndDagger/Player-DaggerAndPistol";
			//PersistentData.upgrades.Add("DoubleJump");
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
		else if (s == "Slide")
			AddSlide();
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
	private void AddSlide() {
		// TODO: give the player the sliding ability
		//player.AddComponent<Crouch>();
	}
	private void RemoveUpgrades() {
		if (player.GetComponent<MoveRight>() != null)
			Destroy(player.GetComponent<MoveRight>());
		if (player.GetComponent<MoveLeft>() != null)
			Destroy(player.GetComponent<MoveLeft>());
		if (player.GetComponent<Jump>() != null)
			Destroy(player.GetComponent<Jump>());
		if (player.GetComponent<Crouch>() != null)
			Destroy(player.GetComponent<Crouch>());
		PersistentData.upgrades = new HashSet<string>();
		AddRightMovement();
		PersistentData.upgrades.Add("MoveRight");
	}
	private void PlayerState2() {
		RemoveUpgrades();
		AddLeftMovement();
		PersistentData.upgrades.Add("MoveLeft");
	}
	private void PlayerState3() {
		PlayerState2();
		AddJump();
		PersistentData.upgrades.Add("Jump");
	}
	private void PlayerState4() {
		PlayerState3();
		AddDagger();
		PersistentData.upgrades.Add("Dagger");
	}
	private void PlayerState5() {
		PlayerState4();
		AddCrouch();
		PersistentData.upgrades.Add("Crouch");
	}
	private void PlayerState6() {
		PlayerState5();
		AddDoubleJump();
		PersistentData.upgrades.Add("DoubleJump");
	}
	private void PlayerState7() {
		PlayerState6();
		AddSlide();
		PersistentData.upgrades.Add("Slide");
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("v") && Input.GetKeyDown("b") && Input.GetKeyDown("n"))
				PersistentData.devMode = true;
		if (PersistentData.devMode) {
			// Move Right
			if (Input.GetKeyDown(KeyCode.F1)) {
				RemoveUpgrades();
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/Peg-Patch/Player-PegPatch") as RuntimeAnimatorController;
			}
			// Move Left + Right
			if (Input.GetKeyDown(KeyCode.F2)) {
				PlayerState2();
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/Peg/Peg") as RuntimeAnimatorController;
			}
			// Jump, Move Left + Right
			if (Input.GetKeyDown(KeyCode.F3)) {
				PlayerState3();
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/Unarmed/Player") as RuntimeAnimatorController;
			}
			// Dagger, Jump, Move Left + Right
			if (Input.GetKeyDown(KeyCode.F4)) {
				PlayerState4();
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/Dagger/Player-Dagger") as RuntimeAnimatorController;
			}
			// Crouch, Dagger, Jump, Move Left + Right
			if (Input.GetKeyDown(KeyCode.F5)) {
				PlayerState5();
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/PistolAndDagger/Player-DaggerAndPistol") as RuntimeAnimatorController;
			}
			// Double Jump, Crouch, Dagger, Move Left + Right
			if (Input.GetKeyDown(KeyCode.F6)) {
				PlayerState6();
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/PistolAndDagger/Player-DaggerAndPistol") as RuntimeAnimatorController;
			}
			// Sliding, Double Jump, Crouch, Dagger, Move Left + Right
			if (Input.GetKeyDown(KeyCode.F7)) {
				PlayerState7();
				player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Animations/female-protag/PistolAndDagger/Player-DaggerAndPistol") as RuntimeAnimatorController;
			}
			// Double the player's speed
			if (Input.GetKeyDown(KeyCode.F9)) {
				player.GetComponent<MoveRight>().speed = player.GetComponent<MoveRight>().speed * 2;
				player.GetComponent<MoveLeft>().speed = player.GetComponent<MoveLeft>().speed * 2;
			}
		}
	}
}
