using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100;
    public float assaultRifledamage;
    public GameObject assaultRifleBullet;

    void Start()
    {
        assaultRifledamage = assaultRifleBullet.GetComponent<VandalBullet>().damageToDrone; 
    }

    private void OnTriggerEnter(Collider hit)
    {
        if(hit.gameObject.tag == "VandalBullet")
        {
            Debug.Log("Damage!");
            health -= assaultRifledamage;

            if(health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
