using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    //скрипт ботов. Пока его писал я чуть не поседел

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
    //в следующей функции если нет цели, то ищем ее. Если есть цель, то направляем бота к ней
    void FixedUpdate()
    {
       if (target)
       {
            rb.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
       } else if (target == null)
       {
            FindFood();               
       }
       
    }

    public float newRadius;



    //функция поиска еды. Реализована через OverlapCircleAll. Забираем все коллайдеры объектов в нужном радиусе newRadius
    //далее сравниваем сколько расстояния до всех целей и выбираем наименьшее расстояние, потом идем к этой цели
    Collider2D[] results; //массив со всеми объектами в радиусе
    float[] distances; //массив с расстояниями до объектов
    void FindFood()
    {

        var hitRay = Physics2D.OverlapCircleAll(transform.position, newRadius);
        distances = new float[hitRay.Length];
        for (int i = 0; i < hitRay.Length; i++)
        {                     
            distances[i] = Vector2.Distance(transform.position, hitRay[i].transform.position);           
            if (hitRay[i].gameObject == transform.gameObject) 
            {
                distances[i] = 10000;//когда бот заносит себя в массив, то отмечаем что расстояние до самого себя будет очень большим чтобы не выбирал себя целью
            }                   
        }

        float minimum = Mathf.Min(distances);//находим меньшее расстояние

        for (int i =0; i<distances.Length;i++)
        {
            if (distances[i] == minimum)
            {
                if (hitRay[i].CompareTag("Food"))
                {
                    target = hitRay[i].transform;// берем только объекты с едой
                    
                }
                else break;
            }
        }





    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, newRadius);
    }

}
