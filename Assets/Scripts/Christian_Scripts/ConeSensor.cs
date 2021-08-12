using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ConeSensor : MonoBehaviour
{
    [SerializeField] SecurityDrone securityDrone;
    [SerializeField] string tagToDetectFor = "TestDetection";

    NavMeshAgent droneAgent;
    Transform target;
    string collidedObjectTag;
    private void Start()
    {
        droneAgent = securityDrone.droneAgent;
        target = securityDrone.target;
    }

    private void OnTriggerEnter(Collider collision)
    {
        collidedObjectTag = collision.gameObject.tag;

        // Allows the security drone to start shooting
        if (collidedObjectTag == tagToDetectFor)
        {
            securityDrone.allowShooting = true;
            droneAgent.SetDestination(target.position);
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
        // Allows the drone to move to new patrol point if it exits the cone trigger
        if (collidedObjectTag == tagToDetectFor)
        {
            securityDrone.MoveToNewPatrolPoint();
        }
    }
}
