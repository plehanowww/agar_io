using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsScript : MonoBehaviour
{
    //функция для включения, управления музыкой

    [SerializeField] Slider slider;
    [SerializeField] Toggle toggle;

    private void Update()
    {

        if (!toggle.isOn)
        {
            AudioManager.instance.SetMusicActive(false);
        }
        else
        {
            AudioManager.instance.SetMusicActive(true);
        }

        AudioManager.instance.SetVolume(slider.value);
    }


}
