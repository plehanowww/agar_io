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
        FindFood();
    }
    Ray2D ray;
    float radius;
    RaycastHit2D hitRay;
    void Update()
    {
       if (target)
       {
            rb.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       } else
       {
            FindFood();         
       }
       
    }  


    void FindFood()
    { 
        for (int trying = 1; !target ; trying++)
        {
            hitRay = Physics2D.CircleCast(transform.position, radius * trying, Vector2.right);
            print(trying);
            if (hitRay && hitRay.transform.CompareTag("Food"))
            {
                print("find");
                target = hitRay.transform;
                break;
            }            
        }               
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    void FindWithRays()
    {
        RaycastHit2D[] RaycastAll();

    }
}
