using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Handles HP manipulation
public class Health : MonoBehaviour {
    public Text healthText;
    public int iFrames;
    private int iFrameCounter;
    public int maxHealth; 
    //Should be modified through Reduce/IncreaseHealth()
    private int health;

    public void Set(int health) {
        this.health = health;
        maxHealth = health;
    }
    
    public int GetCurrentHealth() {
        return health;
    }

    void Start() {
        health = maxHealth;
        iFrameCounter = 0;
    }

    //Reduce character's health by a value, returns current health, 0 if dead, negative if immune or dead
    public int ReduceHealth(int damage) {
        if (iFrameCounter > 0) 
            return -1;
        iFrameCounter = iFrames;
        health -= damage;
        if (health <= 0)
            if (gameObject.CompareTag("Player"))
                PlayerDied();
            else 
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

    private void PlayerDied() {
        SceneManager.LoadScene("MainMenu");
    }

    void Update() {
        if (iFrameCounter > 0) {
            Color c = GetComponent<SpriteRenderer>().color;
            if (iFrameCounter % 2 == 0)
                c.a = 0;
            else
                c.a = 1;
            GetComponent<SpriteRenderer>().color = c;
            iFrameCounter--;
        }
        healthText.text = "" + string.Format("Health: {0,3}/",health) + maxHealth;
    }
}
