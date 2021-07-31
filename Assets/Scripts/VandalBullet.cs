using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VandalBullet : MonoBehaviour
{
    public float movementSpeed;
    public float sentryDamage;
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sentry")
        {
            target.GetComponent<Sentry>().sentryHealth -= sentryDamage;
            Destroy(gameObject);
        }
    }
}
