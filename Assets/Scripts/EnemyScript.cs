using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health = 50f;
    public float damage = 10f;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bridge")
        {
            collision.gameObject.GetComponent<BridgeControl>().DamageTaken();
        }
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerController>().TakeDamage(damage);
        }
        if(collision.gameObject.tag == "Buddy")
        {
            collision.gameObject.GetComponent<player2Controls>().TakeDamage(damage);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
