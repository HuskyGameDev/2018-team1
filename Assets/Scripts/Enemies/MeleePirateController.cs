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
    void FaceReverse() {
        GetComponent<SpriteRenderer>().flipX = true;
        Vector3 pos = meleeAttack.transform.localPosition;
        pos.x = -.7f;
        meleeAttack.transform.localPosition = pos;
    }
    void FaceStandard() {
        GetComponent<SpriteRenderer>().flipX = false;
        Vector3 pos = meleeAttack.transform.localPosition;
        pos.x = .7f;
        meleeAttack.transform.localPosition = pos;
    }
    void ToggleHurtBox() {
        meleeAttack.enabled = !meleeAttack.enabled;
    }
    void HurtBoxEnable() {
        meleeAttack.enabled = true;
    }
    void HurtBoxDisable() {
        meleeAttack.enabled = false;
    }
	// Update is called once per frame
	void Update () {
        if (seenPlayer) {
            if ((player.position - transform.position).magnitude < attackReach) 
                Attack();
        }
	}
    private void Attack() {
        animator.SetTrigger("Attack");
    }
}