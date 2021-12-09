using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class MainMenuAudio : MonoBehaviour
{
    private static MainMenuAudio instance;

    void Awake()
    {
        if (MainMenuAudio.instance == null)
        {
            MainMenuAudio.instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void turnMusicOff()
    {        
        if (instance != null)
        {
            
            this.GetComponent<AudioSource>().Stop();
            Destroy(this.gameObject);
            MainMenuAudio.instance = null;
        }
    }

    void OnApplicationQuit()
    {
        MainMenuAudio.instance = null;
    }
}

