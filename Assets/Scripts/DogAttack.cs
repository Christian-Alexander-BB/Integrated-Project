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
    [SerializeField] GameObject bullet;
    [SerializeField] Transform dogLefteye;
    [SerializeField] Transform dogRighteye;
    


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GetTargetPosition();
    }

    void GetTargetPosition()
    {
        dogAgent = GetComponent<NavMeshAgent>();
        dogAgent.SetDestination(target.position);
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            //Rotation of bullet
            dogLefteye.transform.localRotation = Quaternion.Euler(90, 0, 0);

            //Bullet appear shooting at dog's eyes
            Instantiate(bullet, dogLefteye.position, dogLefteye.transform.rotation);
            Instantiate(bullet, dogRighteye.position, dogLefteye.transform.rotation);

            yield return new WaitForSeconds(1f);

        }
    }
}