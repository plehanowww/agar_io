using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingFood : MonoBehaviour
{
    [SerializeField] int valuePerFoodCell;
    CircleCollider2D collider;
    private void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Food"))
        {           
            if (GetComponent<PlayerStats>())
            {
                float offset = Vector2.Distance(collision.transform.position, transform.position);
 
                if (offset <= collider.bounds.size.x / 2)
                {
                    GetComponent<PlayerStats>().EatingFood(valuePerFoodCell);
                    Destroy(collision.gameObject);
                }
                //print(GetComponent<SpriteRenderer>().bounds.size.x);               
            }
        }
    }
    Vector2 foodPos;
    void IsCenterInside(GameObject obj)
    {
        if (Vector2.Distance(obj.transform.position, transform.position)  <= collider.radius)
        {

        }
    }
}