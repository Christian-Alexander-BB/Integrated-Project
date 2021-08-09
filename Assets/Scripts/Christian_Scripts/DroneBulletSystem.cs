using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneBulletSystem : MonoBehaviour
{
    Rigidbody droneBulletRB;

    public float bulletSpeed = 5f;
    public float bulletDespawnTime = 5f;
    
    void Start()
    {
        // Adds an instant force to the bullet to give it a constant velocity
        droneBulletRB = GetComponent<Rigidbody>();
        droneBulletRB.AddForce(Vector3.Normalize(transform.up) * bulletSpeed);

        StartCoroutine("waitForDestroyBullet");
    }

    IEnumerator waitForDestroyBullet()
    {
        //Waits for bulletDespawnTime number of seconds before destroying the GameObject so that bullets don't waste processing power
        yield return new WaitForSeconds(bulletDespawnTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
