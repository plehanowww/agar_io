using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField] GameObject foodObject;
    [SerializeField] int maxFood;
    [SerializeField] int currFood;
    BoxCollider2D collider;
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        MassSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void MassSpawn()
    {
        for (int i = 0; i <= maxFood-1; i++ )
        {
            float randomX = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            float randomY = Random.Range(collider.bounds.min.y, collider.bounds.max.y);
            Vector2 randomPos = new Vector2(randomX, randomY);
            Instantiate(foodObject, randomPos, foodObject.transform.rotation);
        }
    }
}
