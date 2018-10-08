using UnityEngine;

public class MeleePirateController :  Controller {
     //Base statistics
    public int startingHealth;
    public int damage;
    public float speed;
    private int timeUntilJump;
    public int minJumpTime;
	public int maxJumpTime;
    public float minJumpForce;
    public float maxJumpForce;
    public float sightRange;
    public Health health;

    // Character Components
    private Rigidbody2D rb;
    private new Collider2D collider;
    private new Transform transform;

    // For deciding what to do
    private bool seenPlayer = false;
    private Transform player;

	// Use this for initialization
	void Start () {
        timeUntilJump = Random.Range(minJumpTime, maxJumpTime);
        health = GetComponent<Health>();
        health.Set(startingHealth);
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        rb.freezeRotation = true;
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
            }
            else 
                MoveLeft(speed);
        }
        else
            MoveLeft(speed);
        // Check if eligible for jumping (grounded and pressing button)
        if (IsGrounded(transform, collider) && timeUntilJump-- == 0) {
            // Jump!
            Jump();
        }
        if (timeUntilJump == -1)
            timeUntilJump = Random.Range(minJumpTime, maxJumpTime);
    }
    public override void Die() {
        GameObject.Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
             player = other.GetComponent<Transform>();
             seenPlayer = true;
        }
    }
    
	// Update is called once per frame
	void Update () {
	}

    //The character jumps
    private void Jump() {
        rb.velocity += new Vector2(0, Random.Range(minJumpForce, maxJumpForce));
    }
}