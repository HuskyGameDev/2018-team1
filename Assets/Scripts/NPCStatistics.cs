using UnityEngine;

// Statistics of the NPCs in the game
public class NPCStatistics : MonoBehaviour {
    //if this is needed to be changed publicly later, be sure to check health <= maxHealth
    private int maxHealth; 

    private int health;
    private int damage;
    private int speed;

    public void Set(int health, int damage, int speed) {
        this.health = health;
        maxHealth = health;
        this.damage = damage;
        this.speed = speed;
    }
    public int GetHealth() {
        return health;
    }
    public int GetDamage() {
        return damage;
    }
    public int getSpeed() {
        return speed;
    }

    //Reduce character's health by a value, returns current health
    public int ReduceHealth(int damage) {
        health -= damage;
        if (health <= 0)
            gameObject.GetComponent<Controller>().Die();
        return health;
    }

    //Increase character's health by a value, returns current health
    public int IncreaseHealth(int heal) {
        health += damage;
        if (health > maxHealth)
            health = maxHealth;
        return health;
    }
}
