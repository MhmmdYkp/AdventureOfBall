using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GamePause = false;


    public GameObject pauseMenuUI;
    public AudioSource audioSource;

    [Header("Buttons")] 
    public GameObject pauseButton;
    public GameObject joyStick;
    public GameObject jumpButton;
    public GameObject musicButton;
    public GameObject muteButton;



    private void Start()
    {

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

    public void OpenPauseMenu()
    {
        if (GamePause)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }   
        
    public void Resume()
    {
        pauseMenuUI.SetActive(false);      
        GamePause = false;

        joyStick.SetActive(true);
        pauseButton.SetActive(true);
        jumpButton.SetActive(true);
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);       
        GamePause = true;

        joyStick.SetActive(false);
        pauseButton.SetActive(false);
        jumpButton.SetActive(false);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("menu");
        GamePause = false;
    }

    public void Quit()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    
    #else
		Application.Quit();

    #endif
    }

    public void SonrakiBolum()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("kayit")); 
    }

    public void YenidenOyna()
    {
        SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name));
        GamePause = false;

        CheckMusicStatus();
    }


    public void Share()
    {
       // System.Diagnostics.Process.Start("https://drive.google.com/drive/folders/14gjVRg9XZDNnHrEVhf5qG5X0LZNK2hzr?usp=sharing");
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
        PlayerPrefs.Save();

    }

     public void CheckMusicStatus()
    {
        if (PlayerPrefs.GetFloat("MuteMusic") == 1)
        {
            musicButton.SetActive(true);
            muteButton.SetActive(false);

        }
        else if (PlayerPrefs.GetFloat("MuteMusic") == 0)
        {
            musicButton.SetActive(false);
            muteButton.SetActive(true);
        }
    }
}
