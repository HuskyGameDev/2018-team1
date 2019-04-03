using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftUpgradeTrigger : MonoBehaviour {

	Collider2D collider;

	// Use this for initialization
	void Start () {
		collider =  GetComponent<Collider2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.CompareTag("Player")) {
			PersistentData.upgrades.Add("MoveLeft");

			otherCollider.gameObject.GetComponent<GameManager>().AddUpgrade("MoveLeft");

			Destroy(gameObject);
		}
	}

	
}
