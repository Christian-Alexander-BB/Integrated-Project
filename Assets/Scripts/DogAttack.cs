using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogAttack : MonoBehaviour
{

    // NavMesh variables
    [SerializeField] Transform target;
    NavMeshAgent dogAgent;


    //Variables
    //[SerializeField] GameObject bullet;
    //[SerializeField] Transform dogLefteye;
    //[SerializeField] Transform dogRighteye;

    private GameObject dogTarget;
    public GameObject dog;
    public bool targetLocked;
    public GameObject bulletSpawnPoint;
    public GameObject dogBullet;

    public float fireTimer;
    private bool shotReady;


    // Start is called before the first frame update
    void Start()
    {
        shotReady = true;
        // disables the mesh and collider of the original bullet so it doesn't affect anything in the game as dog has not detected enemies yet
        dogBullet.GetComponent<MeshRenderer>().enabled = false;
        dogBullet.GetComponent<SphereCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetLocked)
        {
            if (dogTarget.activeInHierarchy)
            {
                // dog to look at target
                dog.transform.LookAt(dogTarget.transform);
            }

            else if (!dogTarget.activeInHierarchy)
            {
                targetLocked = false;
            }

            // if it is allowed to attack, shoot
            if (shotReady)
            {
                Attack();
            }
        }

        else if (!targetLocked)
        {
            // just follow player
        }


        //GetTargetPosition();
    }

    void GetTargetPosition()
    {
        dogAgent = GetComponent<NavMeshAgent>();
        dogAgent.SetDestination(target.position);
    }

    //IEnumerator Shoot()
    //{
    //    while (true)
    //    {
    //        //Rotation of bullet
    //        dogLefteye.transform.localRotation = Quaternion.Euler(90, 0, 0);
    //
    //        //Bullet appear shooting at dog's eyes
    //        Instantiate(bullet, dogLefteye.position, dogLefteye.transform.rotation);
    //        Instantiate(bullet, dogRighteye.position, dogLefteye.transform.rotation);
    //
    //        yield return new WaitForSeconds(1f);
    //
    //    }
    //}

    void Attack()
    {
        // instantiates the original bullet
        Transform _dogBullet = Instantiate(dogBullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        _dogBullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        // this is to allow the mesh and the collider of the bullet to reappear for the instantiated bullets only
        dogBullet.GetComponent<MeshRenderer>().enabled = true;
        dogBullet.GetComponent<SphereCollider>().enabled = true;

        // set a duration for the bullet to travel before destroying it
        Destroy(_dogBullet.gameObject, 10);

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
        if (other.tag == "SentryDamage" && !targetLocked)
        {
            // set the sentry as target and lock target
            dogTarget = other.gameObject;
            targetLocked = true;
        }

        else if (other.tag == "Drone")
        {
            dogTarget = other.gameObject;
            targetLocked = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        targetLocked = false;
    }
}