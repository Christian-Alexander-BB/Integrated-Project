using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : MonoBehaviour
{
    private GameObject target;
    public bool targetLocked;

    public float sentryHealth = 50;

    public GameObject sentryTopPart;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public float fireTimer;
    private bool shotReady;

    void Start()
    {
        shotReady = true;
    }

    void Update()
    {
        // shooting and detecting enemies
        if (targetLocked)
        {
            sentryTopPart.transform.LookAt(target.transform);

            if (shotReady)
            {
                Shoot();
            }
        }

        if (sentryHealth <= 0)
        {
            shotReady = false;
            gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
        Transform _bullet = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        shotReady = false;
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shotReady = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            targetLocked = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        targetLocked = false;
    }
}
