using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] GameObject securityDroneBullet;
    public float health = 100f;
    float droneBulletDamage;

    private void Start()
    {
        droneBulletDamage = securityDroneBullet.GetComponent<DroneBullets>().bulletDamage;
    }

    void Update()
    {
        // if player have less than or equals to 0 health, player dies
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        //show game over UI
        Time.timeScale = 0;
        SceneManager.LoadScene(2);
    }
}
