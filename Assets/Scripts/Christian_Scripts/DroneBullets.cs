using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBullets : MonoBehaviour
{   
    Rigidbody droneBulletRB;

    [SerializeField] float bulletSpeed = 5f;
    [SerializeField] float bulletDespawnTimeSeconds = 5f;

    public float bulletDamage = 20f;

    [HideInInspector] public Transform target;
    float playerHealth;

    void Start()
    {
        // Adds an instant force to the bullet to give it a constant velocity
        transform.LookAt(target, Vector3.up);
        droneBulletRB = GetComponent<Rigidbody>();

        droneBulletRB.AddForce(Vector3.Normalize(transform.forward) * bulletSpeed);
        //Debug.Log(target.gameObject.name);

        // Sentry activates its shooting system
        StartCoroutine("waitForDestroyBullet");
    }

    IEnumerator waitForDestroyBullet()
    {
        //Waits for bulletDespawnTime number of seconds before destroying the GameObject so that bullets do not waste computing power
        yield return new WaitForSeconds(bulletDespawnTimeSeconds);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Checks if the bullet hits the player and kills the player if they are at low health. 
        if(collision.gameObject.tag == "Player")
        {
            playerHealth = (collision.gameObject.GetComponent<PlayerHealth>().health -= bulletDamage);

            if(playerHealth <= 0)
            {
                collision.gameObject.GetComponent<PlayerHealth>().Die();
            }
        }

        //Destroys the bullet when it hits something so that it does not waste computing power
        if (collision.gameObject.tag != "SecurityDrone")
        {
            Destroy(gameObject);
        }
    }
}
