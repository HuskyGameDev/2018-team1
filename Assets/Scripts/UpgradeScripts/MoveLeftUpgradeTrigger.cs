using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftUpgradeTrigger : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.CompareTag("Player")) {
			PersistentData.upgrades.Add("MoveLeft");

			otherCollider.gameObject.GetComponent<GameManager>().AddUpgrade("MoveLeft");

			Destroy(gameObject);
		}
	}
}
