using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogAttack : MonoBehaviour
{

    // Initialize NavMesh variables
    [SerializeField] Transform target;
    NavMeshAgent droneAgent;

    //Initialize guns and shooting variables
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform dogLeftPos;
    [SerializeField] Transform dogRightPos;
    [SerializeField] bool allowShooting = true;


    // Start is called before the first frame update
    void Start()
    {
        if (allowShooting)
        {
            StartCoroutine("Shoot");
        }
    }

    // Update is called once per frame
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
            dogLeftPos.transform.localRotation = Quaternion.Euler(90, 0, 0);

            //Spawns bullets at the gun area of the drone.
            Instantiate(bulletPrefab, dogLeftPos.position, dogLeftPos.transform.rotation);
            Instantiate(bulletPrefab, dogRightPos.position, dogLeftPos.transform.rotation);

            yield return new WaitForSeconds(1f);

        }
    }
}
