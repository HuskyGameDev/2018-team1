using UnityEngine;
using System.Collections;
public class PirateKingController :  Controller {
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
    public Transform player;

    public Collider2D meleeAttackLeft;
    public Collider2D meleeAttackRight;
	// Use this for initialization

    // for deciding where to jump (back to start)
    private float startPosX;
    private Scale scalar;
    private SpriteRenderer spriteRenderer;
    // The range at which the pirate king will jump towards the player to get closer
    public float jumpRange;

    private bool finalState = false;
    public Vector3 finalPosition;
	void Start () {
        timeUntilJump = Random.Range(minJumpTime, maxJumpTime);
        health = GetComponent<Health>();
        health.Set(startingHealth);
        transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        rb2d.freezeRotation = true;
        startPosX = transform.position.x;
        scalar = GetComponent<Scale>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    // called once per physics step
    private void FixedUpdate() {
        if (!finalState) {
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
        }
        // Check if time to jump
        if (timeUntilJump-- == 0 && !finalState) {
            // Jump!
            AttemptJump();
        }
        if (timeUntilJump == -1)
            timeUntilJump = Random.Range(minJumpTime, maxJumpTime);
        if (health.GetCurrentHealth() / (float) health.maxHealth < .125f && !finalState) {
            finalState = true;
            StartCoroutine(FinalJump());
        }
    }
    
    protected void JumpRight() {
        rb2d.AddForce(300 * (transform.up * 2 + transform.right) * Random.Range(minJumpForce, maxJumpForce) * Time.deltaTime, ForceMode2D.Impulse);
    }
    protected void JumpLeft() {
        rb2d.AddForce(300 * (transform.up * 2 - transform.right) * Random.Range(minJumpForce, maxJumpForce) * Time.deltaTime, ForceMode2D.Impulse);
    }
    private void AttemptJump() {
         // Check if eligible for jumping (grounded)
        if (isGrounded()) {
            if ((player.position - transform.position).magnitude > jumpRange) {
                float angle = Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg;
                // magnitude < 90 means on right, > 90 means on left
                if (angle < 90 && angle >= 0 || angle > -90 && angle <= 0)
                    StartCoroutine(JumpRightCoroutine());
                else
                    StartCoroutine(JumpLeftCoroutine());
            }
            // Jump!
            else if (transform.position.x < startPosX)
                StartCoroutine(JumpRightCoroutine());
            else
                StartCoroutine(JumpLeftCoroutine());
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
    void ToggleHurtBox() {
        meleeAttackLeft.enabled = !meleeAttackLeft.enabled;
    }
    void HurtBoxEnable() {
        meleeAttackLeft.enabled = true;
        meleeAttackRight.enabled = true;
    }
    void HurtBoxDisable() {
        meleeAttackLeft.enabled = false;
        meleeAttackRight.enabled = false;
    }
	// Update is called once per frame
	void Update () {
        if (seenPlayer) {
            if ((player.position - transform.position).magnitude < attackReach && !stop) {
                StartCoroutine(AttackCoroutine());
            }
        }
        float  healtPercentage = health.GetCurrentHealth() / (float) health.maxHealth;
        Color c = new Color(255, 255 * healtPercentage, 255 * healtPercentage);
        spriteRenderer.color = c;
	}
    private IEnumerator AttackCoroutine() {
        stop = true;
        yield return new WaitForSeconds(.25f);
        animator.SetTrigger("Melee");
        stop = false;
    }
    private IEnumerator JumpRightCoroutine() {
        stop = true;
        yield return new WaitForSeconds(.75f);
        JumpRight();
        stop = false;
    }
    private IEnumerator JumpLeftCoroutine() {
        stop = true;
        yield return new WaitForSeconds(.75f);
        JumpLeft();
        stop = false;
    }
    private IEnumerator FinalJump() {
        stop = true;
        yield return new WaitForSeconds(1.5f);
        rb2d.AddForce(300 * (transform.up * 3 + transform.right * 12) * Random.Range(minJumpForce, maxJumpForce) * Time.deltaTime, ForceMode2D.Impulse);
        finalState = true;
        yield return new WaitForSeconds(.5f);
        rb2d.velocity = new Vector2 (0, 0);
        transform.position = finalPosition;
        stop = false;
    }
}