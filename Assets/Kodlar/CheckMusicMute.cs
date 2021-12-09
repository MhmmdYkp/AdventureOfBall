using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMusicMute : MonoBehaviour
{
    public static AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("MuteMusic", 1f);

        if (PlayerPrefs.GetFloat("MuteMusic") == 0)
        {
            GetComponent<AudioSource>().volume = 0;
        }
        else
        {
            GetComponent<AudioSource>().volume = 1;
        }
    } 

    public void UpdateVolume()
    {

        if (PlayerPrefs.GetFloat("MuteMusic") == 0)
        {
            GetComponent<AudioSource>().volume = 1;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0;
        }
    }
}
