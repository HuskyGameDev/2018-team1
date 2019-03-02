using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public Collider2D meleeAttack;
    private int attacking;
    // Update is called once per frame
    void Update()
    {
        if (attacking > 0) {
            attacking--;
            if (attacking == 0)
                meleeAttack.enabled = false;
        }
        if (Input.GetButtonDown("MeleeAttack")) {
            meleeAttack.enabled = true;
            attacking = 4;
        }
    }
}
