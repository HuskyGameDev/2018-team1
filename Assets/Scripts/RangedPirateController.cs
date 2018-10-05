using UnityEngine;

public class RangedPirateController : MonoBehaviour, Controller {
    public int health;
    public int damage;
    public int speed;
    private int framesUntilJump;
    public int minJumpTime = 12;
	public int maxJumpTime = 50;
	// Use this for initialization
	void Start () {
        framesUntilJump = Random.Range(minJumpTime, maxJumpTime);
        gameObject.GetComponent<NPCStatistics>().Set(health, damage, speed);
	}
	
    public void Die() {
        GameObject.Destroy(gameObject);
    }
	// Update is called once per frame
	void Update () {
        MoveLeft();
        if (framesUntilJump-- == 0) {
            Jump();
            framesUntilJump = Random.Range(minJumpTime, maxJumpTime);
        }
	}

    //The character jumps
    private void Jump() {

    }
    //The character moves left
    private void MoveLeft() {

    }
}
