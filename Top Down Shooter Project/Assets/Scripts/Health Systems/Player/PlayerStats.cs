using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject player;

    public float invincibilityLength = 2f;
    public float invincibilityCounter;

    public Renderer playerRend;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    public Vector2 respawnPoint;
    public float respawnDelay = 2f;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        respawnPoint = player.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "EnemyProjectile")
        {
            HurtPlayer(1);
        }

    }

    void Update()
    {
         if (invincibilityCounter > 0)
          {
                invincibilityCounter -= Time.deltaTime;

                flashCounter -= Time.deltaTime;

                if (flashCounter <= 0)
                {
                    playerRend.enabled = !playerRend.enabled;
                    flashCounter = flashLength;
                }

                if (invincibilityCounter <= 0)
                {
                    playerRend.enabled = true;
                }
          }
    }

    public void HurtPlayer(int damage)
    {
        if (invincibilityCounter <= 0)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Respawn();
            }
            else
            {
                invincibilityCounter = invincibilityLength;

                playerRend.enabled = false;

                flashCounter = flashLength;
            }
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Respawn()
    {
        if (!isRespawning)
        {
            StartCoroutine("RespawnDelay");
        }
    }

    public IEnumerator RespawnDelay()
    {
        isRespawning = true;
        player.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        isRespawning = false;
        player.SetActive(true);


        player.transform.position = respawnPoint;
        currentHealth = maxHealth;

        invincibilityCounter = invincibilityLength;
        playerRend.enabled = false;
        flashCounter = flashLength;
    }
}
