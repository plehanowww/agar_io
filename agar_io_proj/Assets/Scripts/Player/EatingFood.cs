using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingFood : MonoBehaviour
{
    //скрипт поедания еды и ботов

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
                float offset = Vector2.Distance(collision.transform.position, transform.position);//измеряем расстояние 
 
                if (offset <= collider.bounds.size.x / 2) // если расстояние стало меньше, чем половина еды, то сьедаем
                {
                    GetComponent<PlayerStats>().EatingFood(valuePerFoodCell);
                    collision.GetComponent<FoodSellScript>().EatDestroy();
                }          
            }
        } 
        if (collision.GetComponent<PlayerStats>())
        {
            float offset = Vector2.Distance(collision.transform.position, transform.position);

            if (offset <= collider.bounds.size.x / 2)
            {
                float enemySize = collision.GetComponent<PlayerStats>().size;
                if (enemySize * 1.09f <= GetComponent<PlayerStats>().size)// чтобы сьесть бота нужно быть на 9%+ больше чем он. Визуально выглядит правдоподобно
                {
                    GetComponent<PlayerStats>().EatingFood(enemySize * 0.8f);//получаем только 80процентов сьеденного врага. Чтобы не слишком имба была
                    Destroy(collision.gameObject);
                }
            }
                
        }
    }
}
