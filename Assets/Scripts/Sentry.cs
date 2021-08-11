using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentry : MonoBehaviour
{
    // set the target to player
    private GameObject target;
    // check if the sentry has a target
    public bool targetLocked;

    // animation for sentry shooting
    public Animator sentryRotation;

    // refer to the part that will rotate around
    public GameObject sentryTopPart;
    // refer to the spawn point of the bullet
    public GameObject bulletSpawnPoint;
    // refer to the bullet that will be shot
    public GameObject bullet;

    // set a cooldown between each shot
    public float fireTimer;
    private bool shotReady;

    void Start()
    {
        // initialise to allow shooting for the sentry
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

        // stops the animation of the sentry shooting if no target is detected
        else if (targetLocked == false)
        {
            sentryRotation.SetBool("sentryActive", false);
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
        // set a duration for the bullet to travel before destroying it
        Destroy(_bullet.gameObject, 10);
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
        // if the player is within the shooting range of the sentry gun, lock onto the player and start shooting
        if (other.tag == "Player")
        {
            target = other.gameObject;
            targetLocked = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // stop locking onto the player, stops firing shots and stays idle if player is out of range
        targetLocked = false;
    }
}
