using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DogFollowPlayer : MonoBehaviour
{
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (_navMeshAgent == null)
        {
            // show error if nav mesh agent is not attacked
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }

        else
        {
            GetPlayerPos();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetPlayerPos(); 
    }

    // get the position of the destination
    void GetPlayerPos()
    {
        if (_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}
