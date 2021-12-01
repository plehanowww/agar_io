using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int size;
    [SerializeField] int startSize;
    CellController controller;
    AIController aiController;
    Vector2 normalSize;
    [SerializeField] bool player;
    private void Start()
    {
        if (player)
        {
            controller = GetComponent<CellController>();
        }   
        else
        {
            aiController = GetComponent<AIController>();
        }
        size = startSize;
        normalSize = new Vector2(0.2f, 0.2f);
    }
    public void EatingFood(int counts)
    {      
        size += counts;
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale + new Vector3(0.15f, 0.15f, 0), Time.deltaTime);
        LoseSpeed(0.005f);
        if (player)
        {
            GetComponent<CameraScaling>().ScaleUp();
        }      
    }
    public void LosingFood(int counts)
    {
        size -= counts;
        transform.localScale = transform.localScale - new Vector3(0.013f, 0.013f, 0);
        if (player)
        {
            GetComponent<CameraScaling>().ScaleDown();
        }       
    }
    void LoseSpeed(float speed)
    {
        if (size < 58)
        {
            if (player)
            {
                controller.speedBySize -= speed;
            }
            else
            {
                aiController.speedBySize -= speed;
            }
           
        }       
    }
}
