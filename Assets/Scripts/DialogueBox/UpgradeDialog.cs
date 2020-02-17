using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeDialog : MonoBehaviour
{
    public string upgradeToAdd;
    public static bool paused = false;
	public GameObject upgradeGetUI;

    public Text upgradeText;
    public Text descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (paused && Sinput.GetButtonDown("Submit"))
		{
			upgradeGot();
		} 
    }

    private void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.CompareTag("Player")) {
			//paused = true;
			upgradeGet();

			// Giant switch statement for EVERY UPGRADE that will/can be gotten in the game
			switch(upgradeToAdd) {
				case "MoveRight":
					upgradeText.text = "You gained the ability to move right!";
					descriptionText.text = "Press 'D' or push right on the left analog stick to move.";
					break;
				case "MoveLeft":
					upgradeText.text = "You gained the ability to move left!";
					descriptionText.text= "Press 'A' or push left on the left analog stick to move.";
					break;
				case "Jump":
					upgradeText.text = "You gained the ability to jump!";
					descriptionText.text = "Press 'space' or the 'A' button to Jump.";
					break;
				case "Crouch":
					upgradeText.text = "You gained the ability to crouch!";
					descriptionText.text = "Press 'S' or push down on the left analog stick to crouch.\nYou can also move while crouching.";
					break;
				case "DoubleJump":
					upgradeText.text = "You gained a second jump!";
					descriptionText.text = "Try jumping again while in airborne";
					break;
				default :
					upgradeText.text = "NOT YET IMPLEMENTED";
					descriptionText.text = "NOT YET IMPLEMENTED";
					break;               
			}
        }
    }

    void upgradeGet() {
		upgradeGetUI.SetActive(true);
		Time.timeScale = 0f;
		paused = true;		
		print("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
    }

    public void upgradeGot() {
		upgradeGetUI.SetActive(false);
		Time.timeScale = 1f;
		paused = false;
	}
}
