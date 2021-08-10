using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vandal : MonoBehaviour
{
    // audio for the gun when shooting
    private AudioSource gunShot;
    // bullet for the vandal
    public GameObject vandalBullet;
    // spawn point of the bullet
    public GameObject vandalBulletSpawnPoint;
    // reference to the player
    public GameObject player;
    // vfx for muzzle flash
    public ParticleSystem muzzleFlash;
    // amount of bullets
    public int ammo;
    
    // cooldown between each shot
    public float fireTimer;
    private bool shotReady;

    // Start is called before the first frame update
    void Start()
    {
        // initialise the shooting of the vandal
        shotReady = true;
        // get the gunshot sound effect
        gunShot = GetComponent<AudioSource>();
        // get the amount of bullets from the collect ammo script
        ammo = player.GetComponent<CollectAmmo>().ammo;
        // disables the mesh and collider of the original bullet so it doesn't affect anything in the game as the player did not press the shoot button
        vandalBullet.GetComponent<MeshRenderer>().enabled = false;
        vandalBullet.GetComponent<SphereCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // gets input if player clicks the shoot button and if there is still ammo
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0 && shotReady)
        {
            // plays the gunshot sound effect
            gunShot.Play();
            // plays the muzzle flash vfx
            muzzleFlash.Play();
            Shoot();
            // minus 1 bullet after firing once
            ammo -= 1;
        }
    }

    // function to shoot vandal and shoot bullet
    void Shoot()
    {
        // instantiates the original bullet
        Transform _vandalBullet = Instantiate(vandalBullet.transform, vandalBulletSpawnPoint.transform.position, Quaternion.identity);
        _vandalBullet.transform.rotation = vandalBulletSpawnPoint.transform.rotation;
        // this is to allow the mesh and the collider of the bullet to reappear for the instantiated bullets only
        _vandalBullet.GetComponent<MeshRenderer>().enabled = true;
        _vandalBullet.GetComponent<SphereCollider>().enabled = true;
        // set a duration for the bullet to travel before destroying it
        Destroy(_vandalBullet.gameObject, 10);
        // set the fire rate of the vandal
        shotReady = false;
        StartCoroutine(FireRate());
    }

    // set the fire rate of the vandal
    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shotReady = true;
    }
}
