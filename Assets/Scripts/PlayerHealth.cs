using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 16;
    public List<GameObject> HealthBar;
    public float InvincibilityTime;

    private int health;
    private float invTimer;
    void Start()
    {
        health = MaxHealth;

    }


    void Update()
    {
        if(invTimer > 0)
        {
            invTimer -= Time.deltaTime;
        }

        for(int i = 0; i < HealthBar.Count; i++)
        {
            if(i > health-1) HealthBar[i].SetActive(false);
            else HealthBar[i].SetActive(true);
        }
    }

    public void Damage(int damage)
    {
        if (invTimer <= 0)
        {
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                SceneManager.LoadScene("GameOver");
            }    
                invTimer = InvincibilityTime;
        }
    }
}
