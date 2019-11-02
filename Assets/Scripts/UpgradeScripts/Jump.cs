using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    // Public properties
    public float jumpForce;
    public int jumpFrameBuffer;
    public int doubleJumpFrameBuffer;
    public LayerMask groundLayer;
    public bool hasDoubleJumpAbility=false;

    // Internal variables
    private int currentJumpFrameBuffer;
    public int currentDoubleJumpFrameBuffer;
    public bool usedSecondJump=false;

    // Player Components
    private Rigidbody2D rb2d;
    private Collider2D collider2d;
    private new Transform transform;

    public void SetValues(float jumpForce, int jumpFrameBuffer,int doubleJumpFrameBuffer, LayerMask groundLayer) {
        this.jumpForce = jumpForce;
        this.jumpFrameBuffer = jumpFrameBuffer;
        this.doubleJumpFrameBuffer=doubleJumpFrameBuffer;
        this.groundLayer = groundLayer;
        
    }
	// Use this for initialization
	void Start () {

        // Gather components
        transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();

    }
	
	// Update is called once per frame
	void Update () {
	}

    // called once per physics step
    private void FixedUpdate() {
        if (isGrounded()) {
            GetComponent<Animator>().SetTrigger("Land");
            usedSecondJump=false;
            currentDoubleJumpFrameBuffer=doubleJumpFrameBuffer;
        }

        // Check if eligible for jumping (grounded and pressing button)
        if ((Sinput.GetAxisRaw("Vertical") > 0 || Sinput.GetAxisRaw("Jump") > 0) && canJump()) {
            // Jump!
            if(!usedSecondJump&&!isGrounded()){
                jump();
                usedSecondJump=true;
                AkSoundEngine.PostEvent("Jump", gameObject);
                GetComponent<Animator>().SetTrigger("Jump");
            }else if (rb2d.velocity.y <= 0.001f){
                jump();
                AkSoundEngine.PostEvent("Jump", gameObject);
                GetComponent<Animator>().SetTrigger("Jump");
            }
        }

        if (currentJumpFrameBuffer > 0) {
            currentJumpFrameBuffer--;
        }
        if(!isGrounded()&&currentDoubleJumpFrameBuffer>0){
            currentDoubleJumpFrameBuffer--;
        }
        
    }

    private void jump(){
        rb2d.velocity=new Vector2(rb2d.velocity.x,0);
        rb2d.AddForce(300 * transform.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
    }

    private bool canJump() {
        
        if (hasDoubleJumpAbility&&!usedSecondJump&&currentDoubleJumpFrameBuffer == 0) {
                return true;
        } else if (isGrounded()&&currentJumpFrameBuffer==0) {
                return true;
        } 
        else {
             currentDoubleJumpFrameBuffer=doubleJumpFrameBuffer;
            return false;
        }
        

    }

    // Raycasting method to check if on the ground (or close enough that the difference is negligible)
    private bool isGrounded() {
        // RaycastHit2D hitLeft = Physics2D.Raycast(collider2d.bounds.center - new Vector3(collider2d.bounds.extents.x * 0.5f, collider2d.bounds.extents.y, 0), -transform.up, 0.3f, groundLayer.value);
        // RaycastHit2D hitRight = Physics2D.Raycast(collider2d.bounds.center - new Vector3(-collider2d.bounds.extents.x * 0.5f, collider2d.bounds.extents.y, 0), -transform.up, 0.3f, groundLayer.value);
		RaycastHit2D hitLeft = Physics2D.Raycast(collider2d.bounds.center - new Vector3(collider2d.bounds.extents.x * 0.9f, collider2d.bounds.extents.y * 0.9f, 0), -transform.up, 0.15f, groundLayer.value);
        RaycastHit2D hitRight = Physics2D.Raycast(collider2d.bounds.center - new Vector3(-collider2d.bounds.extents.x * 0.9f, collider2d.bounds.extents.y * 0.9f, 0), -transform.up, 0.15f, groundLayer.value);

        Vector3 normalizedUp = Vector3.Normalize(transform.up);

        Vector3 leftNormal = Vector3.Normalize(hitLeft.normal);
        Vector3 rightNormal = Vector3.Normalize(hitRight.normal);

        if (hitLeft && hitLeft.collider.OverlapPoint(hitLeft.point + new Vector2(0.0f, 0.01f))) {
            leftNormal *= -1;
        }
        if (hitRight && hitRight.collider.OverlapPoint(hitRight.point + new Vector2(0.0f, 0.01f))) {
            rightNormal *= -1;
        }

        bool leftGrounded = Vector3.Dot(leftNormal, normalizedUp) > 0;
        bool rightGrounded = Vector3.Dot(rightNormal, normalizedUp) > 0;
        // bool leftGrounded = leftNormal.Equals(normalizedUp);
        // bool rightGrounded = rightNormal.Equals(normalizedUp);

        if (leftGrounded || rightGrounded) {
            return true;
        }
        
        return false;
    }
    public void addDoubleJump(){
        hasDoubleJumpAbility=true;
    }
}