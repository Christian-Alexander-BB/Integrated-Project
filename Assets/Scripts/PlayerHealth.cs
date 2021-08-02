using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;

    // Update is called once per frame
    void Update()
    {
        // if player have less than or equals to 0 health, player dies
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //show game over UI
        Time.timeScale = 0;
        SceneManager.LoadScene(2);
    }
}
