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
                    collision.GetComponent<FoodSellScript>().EatDestroy();
                }
                //print(GetComponent<SpriteRenderer>().bounds.size.x);               
            }
        }
    }
}
