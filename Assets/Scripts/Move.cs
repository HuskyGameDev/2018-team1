using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //check if the player wants to move horizontally
        float moveHorizontal = Input.GetAxis("Horizontal");
        //you can move right by default
        if (moveHorizontal > 0) {
            print("you are moving right.");
          // but you can't move left until acquiring relevant upgrade
        } else if (moveHorizontal < 0 && Upgrade.canMoveLeft == false) {
            print("you can't do that yet");
          // upgrade ahs been acquired
        } else if (moveHorizontal < 0 && Upgrade.canMoveLeft == true) {
            print("you are moving left");
        }

        float moveVertical = Input.GetAxis("Vertical");

        // the player's ability to jump
        if (moveVertical > 0 && Upgrade.canJump == true) {
            print("you jumped");
        } else if (moveVertical > 0 && Upgrade.canJump == false) {
            print("you can't do that yet");
        }

        // the player's ability to crouch
        if (moveVertical < 0 && Upgrade.canCrouch == true){
            print("you are crouching");
        } else if (moveVertical < 0 && Upgrade.canCrouch == false) {
            print("you can't do that yet");
        }

        // the player's ability to swing a sword
        if (Input.GetKeyDown("q") && Upgrade.canSlash == false) {
            print("you can't do that yet");
        } else if (Input.GetKeyDown("q") && Upgrade.canSlash == true) {
            print("shwing");
        }

        // the player's ability to shoot their gun
        if (Input.GetKeyDown("e") && Upgrade.canShoot == false) {
            print("you can't do that yet");
        } else if (Input.GetKeyDown("e") && Upgrade.canShoot == true) {
            print("pew pew");
        }
	}
}
