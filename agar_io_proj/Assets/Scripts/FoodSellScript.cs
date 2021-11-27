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
            if (GetComponentInParent<FoodSpawner>())
            {           
                GetComponentInParent<FoodSpawner>().Spawn();
            }
        }
        Destroy(gameObject);
    }    
}
