using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // red screen
    public GameObject redScreen;
    // speed of the bullet 
    public float movementSpeed;
    // damage the bullet do to the player
    public float damage;
    // player
    public GameObject target;
    // timer
    public float timer;

    // Update is called once per frame
    void Update()
    {
        // movement for the bullet
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);

        // check if the player is still taking damage
        if (target.GetComponent<PlayerHealth>().timer3 <= 2f)
        {
            target.GetComponent<PlayerHealth>().timer3 += Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // if the bullet hits the player, decreases the health of the player and destroys the bullet
        if (other.tag == "Player")
        {
            target = other.gameObject;
            // stops the timer that detects whether they player has stopped taking damage
            target.GetComponent<PlayerHealth>().timer3 = 0;
            // player takes damage
            target.GetComponent<PlayerHealth>().health -= damage;
            // stops player health regen
            target.GetComponent<PlayerHealth>().notTakingDamage = false;
            // takes damage panel
            redScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
