using UnityEngine;

// Handles HP manipulation
public class Health : MonoBehaviour {
    public int maxHealth; 

    //Should be modified through Reduce/IncreaseHealth()
    private int health;

    public void Set(int health) {
        this.health = health;
        maxHealth = health;
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
