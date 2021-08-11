using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBullet : MonoBehaviour
{
    // movement speed of dog bullet
    public float movementSpeed;
    // bullet damage to the sentry
    public float sentryDamage = 2f;
    // target the dog will be shooting at
    public GameObject dogTarget;

    // sentry gun (targets)
    public GameObject target1;
    public GameObject target2;

    // vfx for damage to the sentry
    public ParticleSystem damageEffect1;
    public ParticleSystem damageEffect2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // movement for the bullet
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SentryDamage")
        {
            // set game object as target for the dog
            dogTarget = other.gameObject;
            if (dogTarget.name == "damageTaker1")
            {
                // deals damage to the sentry and show vfx, destroys bullet after hitting
                damageEffect1.Play();
                target1.GetComponent<SentryHealth1>().sentryHealth1 -= sentryDamage;
                Destroy(gameObject);
            }

            // health system for sentry 2
            if (dogTarget.name == "damageTaker2")
            {
                // deals damage to the sentry and show vfx, destroys bullet after hitting
                damageEffect2.Play();
                target2.GetComponent<SentryHealth2>().sentryHealth2 -= sentryDamage;
                Destroy(gameObject);
            }

        }

        else if (other.tag == "Drone")
        {
            dogTarget = other.gameObject;

        }

    }
}
