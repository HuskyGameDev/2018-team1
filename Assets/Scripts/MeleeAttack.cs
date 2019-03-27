using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour {

    public int dmg;
	public GameObject attacker;

    private void OnTriggerEnter2D(Collider2D col) {

		if (attacker.CompareTag("Player") && col.isTrigger != true && col.gameObject.CompareTag("Enemy")) {
            col.SendMessageUpwards("ReduceHealth", dmg);
        }

		if (attacker.CompareTag("Enemy") && !col.isTrigger && col.gameObject.CompareTag("Player")) {
			col.SendMessageUpwards("ReduceHealth", dmg);
		}
	}
}
