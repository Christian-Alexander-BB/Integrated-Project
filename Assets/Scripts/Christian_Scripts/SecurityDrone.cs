using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SecurityDrone : MonoBehaviour
{
    // Initialize NavMesh and patrolling variables
    [SerializeField] List<Transform> patrolPoints;
    [SerializeField] bool knowPlayerLoc = false;

    int numOfPatrolPoints;
    int newPatrolPointChosen;
    int currentPatrolPointInt = 0; // The NavMeshAgent will go to patrolPoints[0] first
    bool allowPickNewPatrolPoint = true;
    float timeStayedInPatrolPoint;
    bool runOnceAlready = false;

    [HideInInspector] public bool allowPatrol = true;
    [HideInInspector] public NavMeshAgent droneAgent; // HideInInspector prevents "droneAgent variable set to none" error in the inspector

    public Transform target;
    public bool playerInRange;

    //Initialize guns and shooting variables
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gunLeftPos;
    [SerializeField] Transform gunRightPos;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] GameObject droneBullets;

    public bool allowShooting;
    public bool stopShooting = false;

    //Initialize drone health and damage taken variables
    [SerializeField] GameObject assaultRifleBullet;

    public float vandalDamage = 20f;
    public float health = 100f;

    //Debug variables


    private void Awake()
    {
        vandalDamage = assaultRifleBullet.GetComponent<VandalBullet>().damageToDrone; // Sets the damage done to the drone from the assault rifle
        droneAgent = GetComponent<NavMeshAgent>(); // Gets the NavMeshAgent component of the drone. Done this way in case script needs to be used in a non-NavMeshAgent gameobject
        numOfPatrolPoints = patrolPoints.Count;

        MoveToNewPatrolPoint();

    }
    void Update()
    {
        if (playerInRange && allowShooting)
        {
            //Debug.Log("Player in range? " + playerInRange + ", Allow shooting? " + allowShooting);
            // Shoot function only gets called once each time the player is detected. The while loop in Shoot() constantly shoots the player until the player leaves 
            StartCoroutine("Shoot");
            allowShooting = false;
        }
    }

    IEnumerator Shoot()
    {
        while (!stopShooting)
        {
            //Rotates the spawn point of bullets so that they point towards the player.
            droneBullets.GetComponent<DroneBullets>().target = target;
            //gunLeftPos.transform.localRotation = Quaternion.Euler(90, 0, 0);

            //Spawns bullets at the left gun area of the drone.
            Instantiate(bulletPrefab, gunLeftPos.position, gunLeftPos.rotation);

            //Wait timeBetweenShots number of seconds before shooting again
            yield return new WaitForSeconds(timeBetweenShots);

            //Spawns bullets at the right gun area of the drone
            Instantiate(bulletPrefab, gunRightPos.position, gunLeftPos.rotation);

            yield return new WaitForSeconds(timeBetweenShots);

        }

        stopShooting = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Take damage from the vandal bullet
        if (collision.gameObject.tag == "VandalBullet")
        {
            DamageDrone();
        }

        //Move to a new patrolpoint
        if(collision.gameObject.tag == "PatrolPoint" && !playerInRange && allowPatrol)
        {
            timeStayedInPatrolPoint = Time.time;
            MoveToNewPatrolPoint();
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(Time.time - timeStayedInPatrolPoint > 2f && allowPatrol)
        {
            SetDestinationToCurrentPatrolPoint();
        }

        else if(Time.time - timeStayedInPatrolPoint > 4f && allowPatrol)
        {
            Debug.Log("It should change patrol location.");
            if (!runOnceAlready)
            {
                PickNewPatrolPoint();
            }

            runOnceAlready = true;
            SetDestinationToCurrentPatrolPoint();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        runOnceAlready = false;
    }

    public void MoveToNewPatrolPoint()
    {

        // Moves the NavMeshAgent to the existing patrol point
        SetDestinationToCurrentPatrolPoint();

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

    public void SetDestinationToCurrentPatrolPoint()
    {
        // Changes the destination of the NavMeshAgent to the new patrol point
        droneAgent.SetDestination(patrolPoints[currentPatrolPointInt].position);
    }
}
