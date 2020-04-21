using UnityEngine;
using System.Collections;
public class BirdController :  Controller {
     //Base statistics
    public int startingHealth;
    public int damage;
    public float speed;
    public int minJumpTime;
	public int maxJumpTime;
    public float sightRange;
    public float attackReach;
    public Health health;
    public Transform flagTransform;

    // Character Components

    // For deciding what to do
    private bool seenPlayer = false;
    private Transform player;

	// Use this for initialization
	void Start () {
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
            float angle = Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg;
            // magnitude < 90 means on right, > 90 means on left
            if (angle < 90 && angle >= 0 || angle > -90 && angle <= 0)
                MoveRight(speed);
            else
                MoveLeft(speed);
        }
        if(transform.position.x>150 || transform.position.x<100 || transform.position.y>96)
            Die();
    }
    
    private void AttemptJump() {
         // Check if eligible for jumping (grounded)
        if (isGrounded()) {
            // Jump!
            Jump();
        }
    }
    public override void Die() {
        FlagMover f=new FlagMover(flagTransform);
        f.move();
        GameObject.Destroy(gameObject);
    }
    private void FlipX() {
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && !seenPlayer) {
             player = other.GetComponent<Transform>();
             seenPlayer = true;
             transform.position = new Vector3(transform.position.x, transform.position.y + 5);
        }
    }
    void FaceReverse() {
        GetComponent<SpriteRenderer>().flipX = true;
    }
    void FaceStandard() {
        GetComponent<SpriteRenderer>().flipX = false;
    }
}