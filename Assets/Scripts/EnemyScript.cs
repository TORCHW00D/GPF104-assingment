﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}