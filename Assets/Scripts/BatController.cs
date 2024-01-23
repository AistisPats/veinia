using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    public int Damage;
    public PlayerHealth Health;

    public float Speed;
    public float SineMovementSpeed;
    public float SineMovementMultiplier;
    private float startingY;
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startingY = transform.position.y;
    }

    void Update()
    {
        rb.velocity = new Vector2(- Speed , Mathf.Sin(transform.position.x*SineMovementSpeed)*SineMovementMultiplier);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("wazap");
        if (collision.CompareTag("Player"))
        {
            
            Health.Damage(Damage);
        }
        else if (collision.CompareTag("EnemyRmoval") || collision.CompareTag("Whip"))
        {
            
            Destroy(gameObject);
        }
    }
}
