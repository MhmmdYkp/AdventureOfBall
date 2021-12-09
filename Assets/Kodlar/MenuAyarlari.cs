using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuAyarlari : MonoBehaviour
{
    /*
    [Header("CONTROLS SETTINGS")]
    public GameObject musicSlider;
    private float sliderValue = 0.2f;
    */

    [Header("Buttons")]
    public AudioSource audioSource;
    public GameObject musicButton;
    public GameObject muteButton;

    public void Start()
    {        
        //musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("MusicVolume");


        if (PlayerPrefs.GetFloat("MuteMusic") == 0)
        {
            musicButton.SetActive(false);
            muteButton.SetActive(true);
        }
        else if (PlayerPrefs.GetFloat("MuteMusic") == 1)
        {
            musicButton.SetActive(true);
            muteButton.SetActive(false);
        }
    }

    public void Update()
    {        
        //sliderValue = musicSlider.GetComponent<Slider>().value;
    }

    public void MusicSlider()
    {
        //PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void MuteMusic()
    {
        if (PlayerPrefs.GetFloat("MuteMusic") == 0)
        {
            PlayerPrefs.SetFloat("MuteMusic", 1);

            musicButton.SetActive(true);
            muteButton.SetActive(false);
        }
        else
        {
            PlayerPrefs.SetFloat("MuteMusic", 0);

            musicButton.SetActive(false);
            muteButton.SetActive(true);

        }
    }
    public void SeviyeyiSifirla()
    {
        PlayerPrefs.DeleteKey("kayit");
    }   

}
