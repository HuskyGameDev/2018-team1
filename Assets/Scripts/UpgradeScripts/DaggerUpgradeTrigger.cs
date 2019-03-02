using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerUpgradeTrigger : MonoBehaviour {
	
	private void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.CompareTag("Player")) {
			PersistentData.upgrades.Add("Dagger");

			otherCollider.gameObject.GetComponent<GameManager>().AddUpgrade("Dagger");

			Destroy(gameObject);
		}
	}

	
}
