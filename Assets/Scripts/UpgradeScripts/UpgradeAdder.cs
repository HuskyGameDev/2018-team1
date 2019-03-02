using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAdder : MonoBehaviour {

	Collider2D collider;

	public string upgradeToAdd;

	// Use this for initialization
	void Start () {
		collider =  GetComponent<Collider2D>();
	}
	
	private void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.CompareTag("Player") && !PersistentData.upgrades.Contains(upgradeToAdd)) {
			PersistentData.upgrades.Add(upgradeToAdd);
			otherCollider.gameObject.GetComponent<GameManager>().AddUpgrade(upgradeToAdd);
			Destroy(gameObject);
		}
	}

	
}
