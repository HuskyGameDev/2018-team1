using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUpgradeTrigger : MonoBehaviour {

	Collider2D collider;

	// Use this for initialization
	void Start () {
		collider =  GetComponent<Collider2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D otherCollider) {
		print("entered collision!");
		if (otherCollider.CompareTag("Player")) {
			PersistentData.upgrades.Add("Jump");

			Jump comp = otherCollider.gameObject.AddComponent<Jump>() as Jump;
			comp.SetValues(4.5f, 6, 1 << LayerMask.NameToLayer("Ground"));

			Destroy(gameObject);
		}
	}

	
}
