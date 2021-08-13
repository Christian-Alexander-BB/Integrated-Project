using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VandalBullet : MonoBehaviour
{
    // speed of the bullet
    public float movementSpeed;
    // damage of the bullet to the sentry guns
    public float sentryDamage;
    // damage of the bullet to the drones
    public float damageToDrone = 20f;

    // sentry gun (targets)
    public GameObject target1;
    public GameObject target2;

    // security drone target
    public GameObject securityDrone;

    // vfx for damage to the sentry
    public ParticleSystem damageEffect1;
    public ParticleSystem damageEffect2;

    // Update is called once per frame
    void Update()
    {
        // movement for the bullet
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided Object: " + other.gameObject.tag);
        // if the bullet hits the sentry gun, decreases the health of the sentry gun and destroys the bullet
        if (other.tag == "SentryDamage")
        {
            // health system for sentry 1
            if (other.gameObject.name == "damageTaker1")
            {
                damageEffect1.Play();
                target1.GetComponent<SentryHealth1>().sentryHealth1 -= sentryDamage;
                Destroy(gameObject);
            }

            // health system for sentry 2
            if (other.gameObject.name == "damageTaker2")
            {
                damageEffect2.Play();
                target2.GetComponent<SentryHealth2>().sentryHealth2 -= sentryDamage;
                Destroy(gameObject);
            } 
        }

        //else if (other.gameObject.tag == "SecurityDrone")
        //{
        //    // Damages the security drone if it's hit.
        //    Debug.Log("COLLIDED WITH DRONE");
        //    securityDrone.GetComponent<SecurityDrone>().health -= securityDrone.GetComponent<SecurityDrone>().vandalDamage;
        //
        //    if(securityDrone.GetComponent<SecurityDrone>().health <= 0)
        //    {
        //        Destroy(other.gameObject);
        //    }
        //}
    }
}
