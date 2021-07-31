using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vandal : MonoBehaviour
{
    public GameObject vandalBullet;
    public GameObject vandalBulletSpawnPoint;
    public GameObject player;
    public int ammo;

    // Start is called before the first frame update
    void Start()
    {
        ammo = player.GetComponent<CollectAmmo>().ammo;
        // disables the mesh and collider of the original bullet so it doesn't affect anything in the game as the player did not press the shoot button
        vandalBullet.GetComponent<MeshRenderer>().enabled = false;
        vandalBullet.GetComponent<SphereCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // gets input if player clicks the shoot button and if there is still ammo
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0)
        {
            Shoot();
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
    }
}
