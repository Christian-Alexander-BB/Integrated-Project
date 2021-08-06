using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecurityDrone : MonoBehaviour
{
    // Initialize NavMesh variables
    [SerializeField] Transform target;
    NavMeshAgent droneAgent;

    //Initialize guns and shooting variables
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gunLeftPos;
    [SerializeField] Transform gunRightPos;
    [SerializeField] bool allowShooting = true;

    //Initialize drone health and damage taken variables
    [SerializeField] float health = 100f;
    [SerializeField] GameObject assaultRifle;
    float vandalDamage;

    [SerializeField] List<PatrolPoint> patrolPoints;


    private void Start()
    {
        if (allowShooting)
        {
            StartCoroutine("Shoot");
        }

        vandalDamage = assaultRifle.GetComponent<VandalBullet>().damageToDrone;
    }
    void Update()
    {
        GetTargetPos();
    }

    void GetTargetPos()
    {
        droneAgent = GetComponent<NavMeshAgent>();
        droneAgent.SetDestination(target.position); // Sets the target destination of the NavMeshAgent every frame.
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            //Rotates the spawn point of bullets so that they move horizontally instead of vertically when they are spawned.
            gunLeftPos.transform.localRotation = Quaternion.Euler(90, 0, 0);

            //Spawns bullets at the gun area of the drone.
            Instantiate(bulletPrefab, gunLeftPos.position, gunLeftPos.transform.rotation);
            Instantiate(bulletPrefab, gunRightPos.position, gunLeftPos.transform.rotation);

            yield return new WaitForSeconds(1f);

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "VandalBullet")
        {
            Debug.Log("Damage!");
            health -= vandalDamage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void IntializePatrol()
    {

    }
}
