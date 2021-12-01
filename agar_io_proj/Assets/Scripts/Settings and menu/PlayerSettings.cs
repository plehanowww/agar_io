using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    public bool gameStarted;
    Color newColor;
    [SerializeField] Slider sliderColor;
    float colorH;
    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
        {
        
            colorH = sliderColor.value;
            
                    
        }
    }
}
