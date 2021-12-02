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
            if (GetComponent<ScoreCounter>())
            {
                GetComponent<ScoreCounter>().ChangeScore(size);
            }            
        }      
    }
    public void LosingFood(int counts)
    {
        size -= counts;
        transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale + new Vector3(0.15f, 0.15f, 0), Time.deltaTime);
        LoseSpeed(-0.005f);
        if (player)
        {
            GetComponent<CameraScaling>().ScaleDown();
            if (GetComponent<ScoreCounter>())
            {
                GetComponent<ScoreCounter>().ChangeScore(size);
            }
        }       
    }
    void LoseSpeed(float speed)
    {
        
        
        if (player)
        {
            if (size < 58)
            {
                controller.speedBySize -= speed;
            } else if (size > 58 && size < 250)
            {
                controller.speedBySize -= speed / 2;
            }
               
        }
        else
        {
            if (size < 58)
            {
                aiController.speedBySize -= speed;
            }
            else if (size > 58 && size < 250)
            {
                controller.speedBySize -= speed / 2;
            }

        }
           
               
    }
}
