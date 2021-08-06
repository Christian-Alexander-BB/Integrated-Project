using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    [SerializeField] protected float debugDrawRadius = 0.5f;
    
    public virtual void OnDrawGizmos()
    {
        // Create a spherical gizmo that shows the transform position of the patrolpoint gameobject
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
}
