using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BaseHealth : MonoBehaviour
{
    public event Action OnDeath;

    float maxHP = 100;
    float hp;

    bool isAlive = true;
    [SerializeField] Slider healthBar;
    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
        healthBar.value = hp / maxHP;
    }

    public void GetDamage(float damage)
    {
        if (isAlive == false) return;
        hp -= damage;
        healthBar.value = hp / maxHP;

        if (hp <= 0.0001f)
        {
            DestroyBase();
        }

    }

    void DestroyBase()
    {
        isAlive = false;
        OnDeath();
    }

    
}
