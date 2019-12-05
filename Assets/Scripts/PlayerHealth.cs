using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : Health
{
    public Text healthText;
    void Update()
    {
        healthText.text = "" + string.Format("Health: {0,3}/", GetCurrentHealth()) + maxHealth;
    }
}
