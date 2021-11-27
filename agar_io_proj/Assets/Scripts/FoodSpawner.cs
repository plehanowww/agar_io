using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject foodObject;
    [SerializeField] int maxFood;
    BoxCollider2D collider;

    float radius;
    float minX, maxX, minY, maxY;

    void Start()
    {
        radius = foodObject.GetComponent<CircleCollider2D>().radius;
        collider = GameObject.Find("Backround_grid").GetComponent<BoxCollider2D>();
        minX = collider.bounds.min.x; maxX = collider.bounds.max.x;
        minY = collider.bounds.min.y; maxY = collider.bounds.max.y;

        GameObject.Find("Backround_grid").GetComponent<BoxCollider2D>().enabled = false;

        MassSpawn();

    }

    void MassSpawn()
    {
        for (int i = 0; i <= maxFood - 1; i++ )
        {
            Spawn();
        }
    }


    Vector2 randomPos;
    public void Spawn()
    {
        do
        {
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);
            Vector2 randomPos = new Vector2(randomX, randomY);

            if (Physics2D.OverlapCircle(randomPos, radius) == null)
            {
                GameObject obj = Instantiate(foodObject, randomPos, foodObject.transform.rotation, gameObject.transform);
                RandomColor(obj);
                break;
            }
        } while (Physics2D.OverlapCircle(randomPos, radius) == null);
    }


    void RandomColor(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
    }
}
