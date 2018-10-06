using UnityEngine;

public abstract class Controller : MonoBehaviour {
    //Character dies
    public abstract void Die();

    protected void MoveLeft(float speed) {
        Vector3 movement = new Vector3(-1, 0, 0);
        transform.position += (movement * speed);
    }
    protected void MoveRight(float speed) {
        Vector3 movement = new Vector3(1, 0, 0);
        transform.position += (movement * speed);
    }
    protected bool IsGrounded(Transform transform, Collider2D collider) {
        return Physics2D.Raycast(transform.position - new Vector3(0, collider.bounds.extents.y * 1.01f, 0), -transform.up, 0.1f);
    }
}
