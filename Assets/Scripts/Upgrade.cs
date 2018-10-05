using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

    public static bool canMoveLeft;
    public static bool canJump;
    public static bool canCrouch;
    public static bool canSlash;
    public static bool canShoot;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (canMoveLeft == false && Input.GetKeyDown("l"))
        {
            canMoveLeft = true;
            print("you can walk left");

        }
        else if (canMoveLeft == true && Input.GetKeyDown("l"))
        {
            canMoveLeft = false;
            print("you can't walk left");
        }

        if (canJump == false && Input.GetKeyDown("j")) {
            canJump = true;
            print("you can jump");
        } else if (canJump == true && Input.GetKeyDown("j")) {
            canJump = false;
            print("you can't jump");
        }

        if (canCrouch == false && Input.GetKeyDown("c"))
        {
            canCrouch = true;
            print("you can crouch");
        }
        else if (canCrouch == true && Input.GetKeyDown("c"))
        {
            canCrouch = false;
            print("you can't crouch");
        }

        if (canShoot == false && Input.GetKeyDown("x"))
        {
            canShoot = true;
            print("you can shoot your gun");
        }
        else if (canShoot == true && Input.GetKeyDown("x"))
        {
            canShoot = false;
            print("you can't shoot your gun");
        }

        if (canSlash == false && Input.GetKeyDown("z"))
        {
            canSlash = true;
            print("you can swing your sword");
        }
        else if (canSlash == true && Input.GetKeyDown("z"))
        {
            canSlash = false;
            print("you can't swing your sword");
        }

    }
}
