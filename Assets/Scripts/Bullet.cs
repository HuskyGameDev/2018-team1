using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public int damage;
    private Rigidbody2D rb;
    private new Collider2D collider;
    private new Transform transform;
    void Start() {
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if (!collision.gameObject.CompareTag("Player"))
            Destroy(this.gameObject); 
    }
	void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
             PlayerInfo player = other.GetComponent<PlayerInfo>();
			 player.ReduceHealth(damage);
             Destroy(this.gameObject);
		}
    }
}
