using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAIController : MonoBehaviour
{
    public Transform[] targets;
    [SerializeField] float radius;

    private void Update()
    {
        FindTargets();
    }
    void FindTargets()
    {
       

        /* Ray ray = new Ray(transform.position, transform.right);

         RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, radius);
         if (hit2D.collider != null)
             Debug.Log(hit2D.collider.name);*/
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
