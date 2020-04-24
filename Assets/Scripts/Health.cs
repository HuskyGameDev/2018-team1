using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
// Handles HP manipulation
public class Health : MonoBehaviour {
    
    public int iFrames;
    private int iFrameCounter;
    public int maxHealth; 
    //Should be modified through Reduce/IncreaseHealth()
    protected int health;

    private float timeA;
    private int fps;
    private int lastFPS;

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
        timeA = Time.timeSinceLevelLoad;
    }

    //Reduce character's health by a value, returns current health, 0 if dead, negative if immune or dead
    public int ReduceHealth(int damage) {
        if (iFrameCounter > 0) 
            return -1;
        iFrameCounter = iFrames*(int)Mathf.Ceil((60.0f/lastFPS));
        health -= damage;
        if (health <= 0) {
            StartCoroutine(DeathCoroutine());
        }
        return health;
    }
    private IEnumerator DeathCoroutine() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = Color.red;
        GetComponent<Animator>().enabled = false;
        foreach (Collider2D col in GetComponentsInChildren<Collider2D>()) {
                col.enabled = false;
            }
        foreach (Collider2D col in GetComponents<Collider2D>()) {
            col.enabled = false;
        }
        Destroy(GetComponent<Rigidbody2D>());
        if (!CompareTag("Player"))
            GetComponent<Controller>().stop = true;
        else {
            if (GetComponent<MoveRight>() != null)
			    Destroy(GetComponent<MoveRight>());
		    if (GetComponent<MoveLeft>() != null)
			    Destroy(GetComponent<MoveLeft>());
		    if (GetComponent<Jump>() != null)
			    Destroy(GetComponent<Jump>());
		    if (GetComponent<PlayerMelee>() != null) {
			    PlayerMelee pm = GetComponent<PlayerMelee>();
			    foreach (Transform child in pm.transform)
				    if (child.name != "Canvas") 
					    Destroy(child.gameObject);
			    Destroy(pm);
		    }
		    if (GetComponent<Crouch>() != null)
			    Destroy(GetComponent<Crouch>());
		    if (GetComponent<Slide>() != null)
			    Destroy(GetComponent<Slide>());
        }
        yield return new WaitForSeconds(1);
        if (gameObject.CompareTag("Player")) 
                PlayerDied();
            else 
                gameObject.GetComponent<Controller>().Die();
    }
    //Increase character's health by a value, returns current health
    public int IncreaseHealth(int heal) {
        health += heal;
        if (health > maxHealth)
            health = maxHealth;
        return health;
    }

    private void PlayerDied() {
        PersistentData.changeScene(SceneManager.GetActiveScene().name, "Overworld");
    }

    void Update() {

        if(Time.timeSinceLevelLoad  - timeA <= 1)
        {
            fps++;
        }
        else
        {
            lastFPS = fps + 1;
            timeA = Time.timeSinceLevelLoad;
            fps = 0;
        }

        if (iFrameCounter > 0) {
            Color c = GetComponent<SpriteRenderer>().color;
            if (iFrameCounter % 2 == 0)
                c.a = 0;
            else
                c.a = 1;
            GetComponent<SpriteRenderer>().color = c;
            iFrameCounter--;
        }
    }
}
