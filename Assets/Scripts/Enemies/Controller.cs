using UnityEngine;

public abstract class Controller : MonoBehaviour {
    //Character dies
    public abstract void Die();
    public LayerMask groundLayer;
    protected Rigidbody2D rb2d;
    protected Collider2D collider2d;
    protected new Transform transform;
    public float minJumpForce;
    public float maxJumpForce;
    public Animator animator;

    protected void MoveLeft(float speed) {
        animator.SetBool("WalkingRight", false);
        animator.SetBool("WalkingLeft", true);
        Vector3 movement = new Vector3(-1, 0, 0);
        transform.position += (10 * movement * speed * Time.deltaTime);
    }
    protected void MoveRight(float speed) {
        animator.SetBool("WalkingLeft", false);
        animator.SetBool("WalkingRight", true);
        Vector3 movement = new Vector3(1, 0, 0);
        transform.position += (10 * movement * speed * Time.deltaTime);
    }
    //The character jumps
    protected void Jump() {
        rb2d.AddForce(300 * transform.up * Random.Range(minJumpForce, maxJumpForce) * Time.deltaTime, ForceMode2D.Impulse);
    }
    // Raycasting method to check if on the ground (or close enough that the difference is negligible)
    protected bool isGrounded() {
        RaycastHit2D hitLeft = Physics2D.Raycast(collider2d.bounds.center - new Vector3(collider2d.bounds.extents.x, collider2d.bounds.extents.y, 0), -transform.up, 0.1f, groundLayer.value);
        RaycastHit2D hitRight = Physics2D.Raycast(collider2d.bounds.center - new Vector3(-collider2d.bounds.extents.x, collider2d.bounds.extents.y, 0), -transform.up, 0.1f, groundLayer.value);

        Vector3 normalizedUp = Vector3.Normalize(transform.up);

        Vector3 leftNormal = Vector3.Normalize(hitLeft.normal);
        Vector3 rightNormal = Vector3.Normalize(hitRight.normal);

        if (hitLeft && hitLeft.collider.OverlapPoint(hitLeft.point + new Vector2(0.0f, 0.01f))) {
            leftNormal *= -1;
        }
        if (hitRight && hitRight.collider.OverlapPoint(hitRight.point + new Vector2(0.0f, 0.01f))) {
            rightNormal *= -1;
        }

        bool leftGrounded = leftNormal.Equals(normalizedUp);
        bool rightGrounded = rightNormal.Equals(normalizedUp);

        if (leftGrounded || rightGrounded) {
            return true;
        }
        
        return false;
    }
}
