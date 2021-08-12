using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ConeSensor : MonoBehaviour
{
    // Collision detection variables
    [SerializeField] SecurityDrone securityDrone;
    [SerializeField] string tagToDetectFor = "TestDetection";

    NavMeshAgent droneAgent;
    Transform target;
    string collidedObjectTag;
    bool playerInRange;

    //Light source variables
    [SerializeField] Light droneSpotLight;
    [SerializeField] Color spotLightColorDefault = Color.white;
    [SerializeField] Color spotLightColorPlayerDetected = Color.red;

    [SerializeField] Collider patrolPoint;

    bool patrolPointsIgnored = false;

    //Debug variables
    bool destinationSetToPlayer = false;
    int exitedNum = 0;

    private void Start()
    {
        InitializeVariables();
    }

    private void OnTriggerEnter(Collider collision)
    {
        collidedObjectTag = collision.gameObject.tag;

        // Allows the security drone to start shooting
        if (collidedObjectTag == tagToDetectFor)
        {
            Debug.Log("Entered");
            securityDrone.allowPatrol = false;
            droneAgent.SetDestination(target.position);
            droneSpotLight.color = spotLightColorPlayerDetected;

            securityDrone.allowShooting = true;
            securityDrone.playerInRange = true;
        }

    }
    private void OnTriggerStay(Collider collision)
    {
        // Follows the player if they are detected
        if(collidedObjectTag == tagToDetectFor)
        {
            droneAgent.SetDestination(target.position);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        // Allows the drone to move to new patrol point if it exits the cone trigger.
        if (collidedObjectTag == tagToDetectFor)
        {
            Debug.Log("Exited");
            securityDrone.MoveToNewPatrolPoint();
            droneSpotLight.color = spotLightColorDefault;

            securityDrone.playerInRange = false;
            securityDrone.allowShooting = false;
            securityDrone.allowPatrol = true;
            securityDrone.stopShooting = true;
        }
         
    }

    private void InitializeVariables()
    {
        // Initializes new variables that need to get existing variables from the SecurityDrone script. 
        droneAgent = securityDrone.droneAgent;
        target = securityDrone.target;
        playerInRange = securityDrone.playerInRange;
    }
}
