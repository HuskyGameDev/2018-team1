using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchUpgradeTrigger : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.CompareTag("Player")) {
			PersistentData.upgrades.Add("Crouch");

			otherCollider.gameObject.GetComponent<GameManager>().AddUpgrade("Crouch");

			Destroy(gameObject);
		}
	}
}
