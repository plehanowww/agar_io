using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
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

        InitializeManager();
    }
    private void InitializeManager()
    {

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
