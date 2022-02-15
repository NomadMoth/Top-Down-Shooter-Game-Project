using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damageToGive = 1;

    public GameObject deathEffect;
    public GameObject hitEffect;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            HurtEnemy(damageToGive);
        }
    }

    public void HurtEnemy(int dmg)
    {
        Instantiate(hitEffect, transform.position, transform.rotation);

        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            gameObject.SetActive(false);
            Destroy(gameObject, 2f);
        }
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
