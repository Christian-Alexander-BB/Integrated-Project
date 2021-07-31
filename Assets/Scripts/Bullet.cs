using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movementSpeed;
    public float damage;
    public GameObject target;

    // Update is called once per frame
    void Update()
    {
        // movement for the bullet
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        // if the bullet hits the player, decreases the health of the player and destroys the bullet
        if (other.tag == "Player")
        {
            target = other.gameObject;
            target.GetComponent<PlayerHealth>().health -= damage;
            Destroy(gameObject);
        }
    }
}
