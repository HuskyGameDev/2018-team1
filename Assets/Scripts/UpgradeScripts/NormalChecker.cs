using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalChecker : MonoBehaviour {


    public LayerMask groundLayer;

    // Player Components
    private Rigidbody2D rb2d;
    private Collider2D collider2d;
    private new Transform transform;
	void Start () {

		transform = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();

		groundLayer = 1 << LayerMask.NameToLayer("Ground");
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit2D hitLeft = Physics2D.Raycast(collider2d.bounds.center - new Vector3(collider2d.bounds.extents.x, 0, 0), -transform.up, 5f, groundLayer.value);
        RaycastHit2D hitRight = Physics2D.Raycast(collider2d.bounds.center - new Vector3(-collider2d.bounds.extents.x, 0, 0), -transform.up, 5f, groundLayer.value);

        Vector3 normalizedUp = Vector3.Normalize(transform.up);

        Vector3 leftNormal = Vector3.Normalize(hitLeft.normal);
        Vector3 rightNormal = Vector3.Normalize(hitRight.normal);

        if (hitLeft && hitLeft.collider.OverlapPoint(hitLeft.point + new Vector2(0.0f, 0.01f))) {
            leftNormal *= -1;
        }
        if (hitRight && hitRight.collider.OverlapPoint(hitRight.point + new Vector2(0.0f, 0.01f))) {
            rightNormal *= -1;
        }

        bool leftSloped = Vector3.Dot(leftNormal, normalizedUp) > 0 && !leftNormal.Equals(normalizedUp);
        bool rightSloped = Vector3.Dot(rightNormal, normalizedUp) > 0 && !rightNormal.Equals(normalizedUp);

		if (leftSloped || rightSloped) {
			rb2d.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
		} else {
			rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
	}
}
