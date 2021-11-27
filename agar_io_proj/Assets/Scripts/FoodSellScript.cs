using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSellScript : MonoBehaviour
{
    [SerializeField] bool foodAfterDeath;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EatDestroy()
    {
        if (foodAfterDeath)
        {
            print("do 1");
            if (GetComponentInParent<FoodSpawner>())
            {
                print("do 2");
                GetComponentInParent<FoodSpawner>().Spawn();
            }
        }
        Destroy(gameObject);
    }    
}
