using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecurityDrone : MonoBehaviour
{
    // Initialize NavMesh and patrolling variables
    [SerializeField] List<Transform> patrolPoints;

    int numOfPatrolPoints;
    int newPatrolPointChosen;
    int currentPatrolPointInt = 0; // The NavMeshAgent will go to patrolPoints[0] first
    bool allowPickNewPatrolPoint = true;

    [HideInInspector] public NavMeshAgent droneAgent; // HideInInspector prevents "droneAgent variable set to none" error in the inspector

    public Transform target;
    public bool playerInRange;

    //Initialize guns and shooting variables
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gunLeftPos;
    [SerializeField] Transform gunRightPos;
    [SerializeField] float timeBetweenShots = 1f;

    public bool allowShooting;

    //Initialize drone health and damage taken variables
    [SerializeField] float health = 100f;
    [SerializeField] GameObject assaultRifleBullet;
    float vandalDamage = 20f;

    //Light source controls
    [SerializeField] Light spotLight;

    Color spotLightColorDefault = Color.white;
    Color spotLightColorPlayerDetected = Color.red;

    private void Awake()
    {
        vandalDamage = assaultRifleBullet.GetComponent<VandalBullet>().damageToDrone; // Sets the damage done to the drone from the assault rifle
        droneAgent = GetComponent<NavMeshAgent>(); // Gets the NavMeshAgent component of the drone. Done this way in case script needs to be used in a non-NavMeshAgent gameobject
        numOfPatrolPoints = patrolPoints.Count;

        MoveToNewPatrolPoint();

    }
    void Update()
    {
        if(playerInRange && allowShooting)
        {
                // Shoot function only gets called once each time the player is detected. The while loop in Shoot() constantly shoots the player until the player leaves 
                Shoot();
                allowShooting = false;
        }

        else
        {
            allowShooting = true;
        }
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

            //Wait timeBetweenShots number of seconds before shooting again
            yield return new WaitForSeconds(timeBetweenShots);

        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Take damage from the vandal bullet
        if (collision.gameObject.tag == "VandalBullet")
        {
            DamageDrone();
        }

        // Move to a new patrolpoint
        else if(collision.gameObject.tag == "PatrolPoint" && !playerInRange)
        {
            MoveToNewPatrolPoint();
        }
    }

    public void MoveToNewPatrolPoint()
    {
        // Moves the NavMeshAgent
        droneAgent.SetDestination(patrolPoints[currentPatrolPointInt].position);

        // Sets a random patrol point for the next target of the NavMeshAgent
        PickNewPatrolPoint();
    }

    public void PickNewPatrolPoint()
    {
        while (allowPickNewPatrolPoint)
        {
            newPatrolPointChosen = Random.Range(0, numOfPatrolPoints);

            // Restarts the loop if the new patrol point is the same as the old one
            if (currentPatrolPointInt == newPatrolPointChosen)
            {
                continue;
            }
            currentPatrolPointInt = newPatrolPointChosen; // Sets the currentPatrolPoint for the next iteration of this function so that the NavMeshAgent will move there

            allowPickNewPatrolPoint = false;
        }

        allowPickNewPatrolPoint = true;
    }

    public void DamageDrone()
    {
        //Take damage from the vandal bullet and potentially allow the drone to be destroyed
        health -= vandalDamage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
