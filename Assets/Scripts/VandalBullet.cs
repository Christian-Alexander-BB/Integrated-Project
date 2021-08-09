using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VandalBullet : MonoBehaviour
{
    public float movementSpeed;
    public float sentryDamage;
    public float damageToDrone = 20f;
    public GameObject target1;
    public GameObject target2;

    // Update is called once per frame
    void Update()
    {
        // movement for the bullet
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        // if the bullet hits the sentry gun, decreases the health of the sentry gun and destroys the bullet
        if (other.tag == "SentryDamage")
        {
            // health system for sentry 1
            if (other.gameObject.name == "damageTaker1")
            {
                target1.GetComponent<SentryHealth1>().sentryHealth1 -= sentryDamage;
                Destroy(gameObject);
            }

            // health system for sentry 2
            if (other.gameObject.name == "damageTaker2")
            {
                target2.GetComponent<SentryHealth2>().sentryHealth2 -= sentryDamage;
                Destroy(gameObject);
            }
            
        }

        Debug.Log("The Bullet Hit: " + other.gameObject.name);
    }
}
