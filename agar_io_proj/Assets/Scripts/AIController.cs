using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] Transform target;
    CircleCollider2D collider;
    [SerializeField] float speed;
    Rigidbody2D rb;
    [SerializeField] float startRadius;
    public float speedBySize = 1;

    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        radius = startRadius;
    }
    Ray2D ray;
    float radius;
    RaycastHit2D hitRay;
    void FixedUpdate()
    {
       if (target)
       {
            rb.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       } else
       {
            FindFood();               
       }
       
    }

    public float newRadius;


    Collider2D[] results;
    float[] distances;
    void FindFood()
    {

        var hitRay = Physics2D.OverlapCircleAll(transform.position, newRadius);
        distances = new float[hitRay.Length];
        for (int i = 0; i < hitRay.Length; i++)
        {                     
            distances[i] = Vector2.Distance(transform.position, hitRay[i].transform.position);           
            if (hitRay[i].gameObject == transform.gameObject)
            {
                distances[i] = 10000;
            }           
        }

        float minimum = Mathf.Min(distances);

        for (int i =0; i<distances.Length;i++)
        {
            if (distances[i] == minimum)
            {
                target = hitRay[i].transform;
            }
        }
        





    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, newRadius);
    }

}
