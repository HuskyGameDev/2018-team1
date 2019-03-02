using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerUpgradeTrigger : MonoBehaviour {

	Collider2D collider;

	// Use this for initialization
	void Start () {
		collider =  GetComponent<Collider2D>();	
	}
	
	private void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.CompareTag("Player")) {
			PersistentData.upgrades.Add("Dagger");

			otherCollider.gameObject.GetComponent<GameManager>().AddUpgrade("Dagger");

			Destroy(gameObject);
		}
	}

	
}
