using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAdder : MonoBehaviour {

	public string upgradeToAdd;
	public string animator;

	// Use this for initialization
	void Start () {
		if (PersistentData.upgrades.Contains(upgradeToAdd)) {
			gameObject.SetActive(false);
		}
	}
	
	private void OnTriggerEnter2D(Collider2D otherCollider) {
		if (otherCollider.CompareTag("Player")) {
			if (!PersistentData.upgrades.Contains(upgradeToAdd)) {
				PersistentData.upgrades.Add(upgradeToAdd);
				otherCollider.gameObject.GetComponent<GameManager>().AddUpgrade(upgradeToAdd);
				otherCollider.gameObject.GetComponent<Animator>().runtimeAnimatorController = Resources.Load(animator) as RuntimeAnimatorController;
				PersistentData.animator = animator;
			}
			Destroy(gameObject);
		}
	}
}
