
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColoringPlayer : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Image player;

    // Update is called once per frame
    void Update()
    {
        player.color = Color.HSVToRGB(slider.value,1,1);
        PlayerPrefs.SetFloat("color", slider.value);
    }
}
