using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject securityDroneBullet;

    // red screen
    public GameObject redScreen;

    // set the max health the player can have
    public float maxHealth = 100;
    // set the current health of the player
    public float health = 100f;
    // set the amount of health the player regen
    public int regeneration = 1;
    // set a timer
    public float timer;
    // bool to check if player is taking damage
    public bool notTakingDamage = true;
    float droneBulletDamage;

    public float testingTimer;

    private void Start()
    {
        droneBulletDamage = securityDroneBullet.GetComponent<DroneBullets>().bulletDamage;
        redScreen.SetActive(false);
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        // health regeneration if player health is more than 0 and less than max health
        if (health < maxHealth && health > 0)
        {
            if (notTakingDamage)
            {
                // timer for regen
                timer += 1;
            }

            // if player is taking damage, stop timer
            else if (!notTakingDamage)
            {
                timer = 0;
            }

            if (timer % 100 == 0)
            {
                // if player is not taking damage, health regen
                if (notTakingDamage)
                {
                    if (timer >= 100)
                    {
                        healthRegen();
                        redScreen.SetActive(false);
                    }
                }
            }
        }

        // if player have less than or equals to 0 health, player dies
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        
    }

    public void Die()
    {
        // load game over screen
        SceneManager.LoadScene(2);
    }

    public void healthRegen()
    {
        // regen health
        health += regeneration;
    }
}
