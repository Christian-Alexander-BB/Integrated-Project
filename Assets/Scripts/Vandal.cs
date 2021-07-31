using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vandal : MonoBehaviour
{
    public GameObject vandalBullet;
    public GameObject vandalBulletSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Transform _vandalBullet = Instantiate(vandalBullet.transform, vandalBulletSpawnPoint.transform.position, Quaternion.identity);
        _vandalBullet.transform.rotation = vandalBulletSpawnPoint.transform.rotation;
    }
}
