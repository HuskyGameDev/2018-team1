using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : Health
{
    public Text healthText;
    public MeleeAttack meleeAttack;
    void Update()
    {
        healthText.text = "" + string.Format("Health: {0,3}/", GetCurrentHealth()) + maxHealth;
    }

    // Couldn't find a better place to put this, it handles the player melee attack toggling/position
    void FaceReverse() {
        Vector3 pos = meleeAttack.transform.localPosition;
        pos.x = -.7f;
        meleeAttack.transform.localPosition = pos;
    }
    void FaceStandard() {
        Vector3 pos = meleeAttack.transform.localPosition;
        pos.x = .7f;
        meleeAttack.transform.localPosition = pos;
    }
    void ToggleHurtBox() {
        meleeAttack.enabled = !meleeAttack.enabled;
    }
    void HurtBoxEnable() {
        meleeAttack.enabled = true;
    }
    void HurtBoxDisable() {
        meleeAttack.enabled = false;
    }
}
