using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

	public int damage;
    public float knockback;
	void OnTriggerEnter2D(Collider2D other) {

        if (other.gameObject.CompareTag("Player")) {
            
			GetComponent<Collider2D>().enabled = false;

            if (other.gameObject.GetComponent<Health>().ReduceHealth(damage) != -1) {
                if (transform.position.x > other.gameObject.transform.position.x) {
                    transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * knockback);
                    other.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * knockback);
                }
                else {
                    transform.parent.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * knockback);
                    other.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1) * knockback);
                }
            }
        }
    }
}
