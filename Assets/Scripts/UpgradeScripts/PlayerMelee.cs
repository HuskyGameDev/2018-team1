using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private Animator animator;

    void Start() {
        animator = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Sinput.GetButtonDown("MeleeAttack")) {
            animator.SetTrigger("Attack");
        }
    }
}
