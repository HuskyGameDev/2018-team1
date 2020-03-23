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
			PlayerState6();
			PersistentData.animator = "Animations/female-protag/PistolAndDagger/Player-DaggerAndPistol";
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
		comp.SetValues(4.5f, 2, 2, 4, 1 << LayerMask.NameToLayer("Ground"));
	}
	private void AddDagger() {
		GameObject attack = new GameObject();
		attack.transform.SetParent(player.transform);
		attack.transform.localPosition = new Vector2(.7f, 0);
		attack.transform.localScale = new Vector2(.9f, 1.5f);

		BoxCollider2D hitbox = attack.AddComponent<BoxCollider2D>() as BoxCollider2D;

		hitbox.isTrigger = true;
		hitbox.enabled = false;

		Hit hit = attack.AddComponent<Hit>() as Hit;
		hit.damage = 35;
		hit.knockback = 1300;

		SpriteRenderer sr = attack.AddComponent<SpriteRenderer>() as SpriteRenderer;
		sr.sprite = Resources.Load<Sprite>("Square") as Sprite;
		sr.color = Color.red;
		sr.sortingLayerName = "Entities";

		PlayerMelee pm = player.AddComponent<PlayerMelee>();
		player.GetComponent<PlayerHealth>().meleeAttack = hitbox;
	}
	private void AddCrouch() {
		player.AddComponent<Crouch>();
	}
	private void AddDoubleJump(){
		player.GetComponent<Jump>().addDoubleJump();
	}
	private void AddSlide() {
		player.AddComponent<Slide>();
	}
	private void RemoveUpgrades() {
		if (player.GetComponent<MoveRight>() != null)
			Destroy(player.GetComponent<MoveRight>());
		if (player.GetComponent<MoveLeft>() != null)
			Destroy(player.GetComponent<MoveLeft>());
		if (player.GetComponent<Jump>() != null)
			Destroy(player.GetComponent<Jump>());
		if (player.GetComponent<PlayerMelee>() != null) {
			PlayerMelee pm = player.GetComponent<PlayerMelee>();
			foreach (Transform child in pm.transform)
				if (child.name != "Canvas") 
					Destroy(child.gameObject);
			Destroy(pm);
		}
		if (player.GetComponent<Crouch>() != null)
			Destroy(player.GetComponent<Crouch>());
		if (player.GetComponent<Slide>() != null)
			Destroy(player.GetComponent<Slide>());
		PersistentData.upgrades = new HashSet<string>();
		AddRightMovement();
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

	void FixedUpdate () {
		
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
