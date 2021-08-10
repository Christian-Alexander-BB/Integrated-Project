using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogAttack : MonoBehaviour
{

    // NavMesh variables
    [SerializeField] Transform target;
    NavMeshAgent droneAgent;


    //Variables
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
        droneAgent.SetDestination(target.position);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            //Rotation of bullet
            dogLeftPos.transform.localRotation = Quaternion.Euler(90, 0, 0);

            //Bullet appear shooting at dog's eyes
            Instantiate(bulletPrefab, dogLeftPos.position, dogLeftPos.transform.rotation);
            Instantiate(bulletPrefab, dogRightPos.position, dogLeftPos.transform.rotation);

            yield return new WaitForSeconds(1f);

        }
    }
}