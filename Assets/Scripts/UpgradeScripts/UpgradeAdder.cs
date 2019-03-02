using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAdder : MonoBehaviour {

	public string upgradeToAdd;

	// Use this for initialization
	void Start () {
		if (PersistentData.upgrades.Contains(upgradeToAdd)) {
			gameObject.SetActive(false);
		}
	}
	
	private void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.CompareTag("Player") && !PersistentData.upgrades.Contains(upgradeToAdd)) {
			PersistentData.upgrades.Add(upgradeToAdd);
			otherCollider.gameObject.GetComponent<GameManager>().AddUpgrade(upgradeToAdd);
			Destroy(gameObject);
		}
	}

	
}
