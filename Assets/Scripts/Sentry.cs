using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : MonoBehaviour
{
    private GameObject target;
    public bool targetLocked;
    public Animator sentryRotation;

    public float sentryHealth = 50;

    public GameObject sentryTopPart;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public float fireTimer;
    private bool shotReady;

    void Start()
    {
        shotReady = true;
        // disables the mesh and collider of the original bullet so it doesn't affect anything in the game as the player is not in the shooting range yet
        bullet.GetComponent<MeshRenderer>().enabled = false;
        bullet.GetComponent<SphereCollider>().enabled = false;
    }

    void Update()
    {
        // shooting and detecting enemies
        if (targetLocked)
        {
            sentryRotation.SetBool("sentryActive", true);
            // looks at the player
            sentryTopPart.transform.LookAt(target.transform);

            // for the cooldown between each shot
            if (shotReady)
            {
                Shoot();
            }
        }

        else if (targetLocked == false)
        {
            sentryRotation.SetBool("sentryActive", false);
        }

        // destroys the sentry gun if sentry gun health is less than or equals to 0
        if (sentryHealth <= 0)
        {
            shotReady = false;
            gameObject.SetActive(false);
        }
    }

    void Shoot()
    {
        // instantiates the original bullet
        Transform _bullet = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        // this is to allow the mesh and the collider of the bullet to reappear for the instantiated bullets only
        _bullet.GetComponent<MeshRenderer>().enabled = true;
        _bullet.GetComponent<SphereCollider>().enabled = true;
        // for the cooldown between each shot
        shotReady = false;
        StartCoroutine(FireRate());
    }

    // for the cooldown between each shot
    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shotReady = true;
    }

    void OnTriggerStay(Collider other)
    {
        // if the player is within the shooting diameter of the sentry gun, lock onto the player and start shooting
        if (other.tag == "Player")
        {
            target = other.gameObject;
            targetLocked = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // stop locking onto the player, stops firing shots and stays idle
        targetLocked = false;
    }
}
