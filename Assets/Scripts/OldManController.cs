using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldManController : MonoBehaviour
{
    public int Damage;
    public PlayerHealth Health;
    public float MovemantSpeed;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = new Vector2(-MovemantSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Health.Damage(Damage);
        }
        else if(collision.CompareTag("EnemyRmoval") || collision.CompareTag("Whip"))
        {
            Destroy(gameObject);
        }
    }
}
