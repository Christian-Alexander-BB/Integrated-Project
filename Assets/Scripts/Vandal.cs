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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammo > 0)
        {
            Shoot();
            ammo -= 1;
        }
    }

    void Shoot()
    {
        Transform _vandalBullet = Instantiate(vandalBullet.transform, vandalBulletSpawnPoint.transform.position, Quaternion.identity);
        _vandalBullet.transform.rotation = vandalBulletSpawnPoint.transform.rotation;
    }
}
