using UnityEngine;

public class MeleePirateController :  Controller {
     //Base statistics
    public int startingHealth;
    public int damage;
    public float speed;
    private int timeUntilJump;
    public int minJumpTime;
	public int maxJumpTime;
    public float sightRange;
    public float attackReach;
    public Health health;

    // Character Components

    // For deciding what to do
    private bool seenPlayer = false;
    private Transform player;

    private int attacking;
    public Collider2D meleeAttack;
	// Use this for initialization
	void Start () {
        timeUntilJump = Random.Range(minJumpTime, maxJumpTime);
        health = GetComponent<Health>();
        health.Set(startingHealth);
        transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        rb2d.freezeRotation = true;
	}

    // called once per physics step
    private void FixedUpdate() {
        if (seenPlayer) {
            if ((player.position - transform.position).magnitude < sightRange) {
                float angle = Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg;
                // magnitude < 90 means on right, > 90 means on left
                if (angle < 90 && angle >= 0 || angle > -90 && angle <= 0)
                    MoveRight(speed);
                else
                    MoveLeft(speed);
                if (angle < 150 && angle >= 30) // If player is above the enemy
                    AttemptJump();
            }
            else 
                MoveLeft(speed);
        }
        else
            MoveLeft(speed);
        // Check if time to jump
        if (timeUntilJump-- == 0) {
            // Jump!
            AttemptJump();
        }
        if (timeUntilJump == -1)
            timeUntilJump = Random.Range(minJumpTime, maxJumpTime);
    }
    
    private void AttemptJump() {
         // Check if eligible for jumping (grounded)
        if (isGrounded()) {
            // Jump!
            Jump();
        }
    }
    public override void Die() {
        GameObject.Destroy(gameObject);
    }
    private void FlipX() {
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
             player = other.GetComponent<Transform>();
             seenPlayer = true;
        }
    }
    
	// Update is called once per frame
	void Update () {
        if (seenPlayer) {
            if ((player.position - transform.position).magnitude < attackReach) 
                Attack();
        }
        if (attacking > 0) {
            attacking--;
            if (attacking == 0) {
                meleeAttack.enabled = false;
            }
        }
	}
    private void Attack() {
        attacking = 4;
        animator.SetTrigger("Attack");
        meleeAttack.enabled = true;
    }
}