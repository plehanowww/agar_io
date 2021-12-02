using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //синглтон для проигрывания музыки в меню и при переходе в игру. Содержит функции включения и отключения звука.

    public static AudioManager instance = null;
    [SerializeField] GameObject allMusic;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource soundEating;

    void Start()
    {
        
        if (instance == null)
        { 
            instance = this; 
        }
        else if (instance == this)
        { 
            Destroy(gameObject); 
        }

        DontDestroyOnLoad(gameObject);

    }

    public void SetMusicActive(bool setting)
    {
        allMusic.SetActive(setting);
    }
    public void SetVolume(float value)
    {
        backgroundMusic.volume = value;
        soundEating.volume = value;
    }
}
