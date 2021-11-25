using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int size;
    [SerializeField] int startSize;
    Vector2 normalSize;
    private void Start()
    {
        size = startSize;
        normalSize = new Vector2(0.2f, 0.2f);
    }
    public void EatingFood(int counts)
    {      
        size += counts;
        transform.localScale = normalSize + size * new Vector2(0.03f, 0.03f);
    }
    public void LosingFood(int counts)
    {
        size -= counts;
        transform.localScale = normalSize + size * new Vector2(0.03f, 0.03f);
    }
}
