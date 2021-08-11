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
    }

    void FixedUpdate()
    {
        timer += 1;

        if (timer >= 100)
        {
            target.GetComponent<PlayerHealth>().notTakingDamage = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        // if the bullet hits the player, decreases the health of the player and destroys the bullet
        if (other.tag == "Player")
        {
            timer = 0;
            target = other.gameObject;
            // player takes damage
            target.GetComponent<PlayerHealth>().health -= damage;
            // stops player health regen
            target.GetComponent<PlayerHealth>().notTakingDamage = false;
            redScreen.SetActive(true);
            Destroy(gameObject);
        }
    }
}
