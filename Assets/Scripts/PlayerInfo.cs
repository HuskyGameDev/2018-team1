using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    // Public fields
    public int maxHealth;

    // Private variables
    private int health;

    // Player Components
    private Rigidbody2D rb;
    private new Collider2D collider;
    private new Transform transform;

	// Use this for initialization
	void Start () {

        health = maxHealth;

        // Gather components
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

        // Prevent player from rotating under all circumstances
        rb.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {

	}
    //Reduce character's health by a value, returns current health (negative allowed)
    public int ReduceHealth(int damage) {
        health -= damage;
        if (health <= 0)
            gameObject.GetComponent<Controller>().Die();
        return health;
    }

    //Increase character's health by a value, returns current health
    public int IncreaseHealth(int heal) {
        health += heal;
        if (health > maxHealth)
            health = maxHealth;
        return health;
    }
}
