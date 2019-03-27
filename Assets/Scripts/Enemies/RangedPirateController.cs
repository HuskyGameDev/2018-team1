using UnityEngine;

public class RangedPirateController : Controller {
    //Base statistics
    public int startingHealth;
    public int damage;
    public float speed;
    private int timeUntilJump;
    public int minJumpTime;
	public int maxJumpTime;
    public float sightRange;
    public Health health;

    // For deciding what to do
    private bool seenPlayer = false;
    private Transform player;

	// Use this for initialization
	void Start () {
        timeUntilJump = Random.Range(minJumpTime, maxJumpTime);
        health = GetComponent<Health>();
        health.Set(startingHealth);
        transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
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
            }
            else 
                MoveLeft(speed);
        }
        else
            MoveLeft(speed);
        // Check if eligible for jumping (grounded and pressing button)
        if (isGrounded() && timeUntilJump-- == 0) {
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
}