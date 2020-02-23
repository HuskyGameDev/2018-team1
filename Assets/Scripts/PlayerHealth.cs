using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : Health
{
    public RectTransform healthBar;

    void Update()
    {
        healthBar.sizeDelta = new Vector2(GetCurrentHealth() * 3, healthBar.sizeDelta.y);
    }
}
