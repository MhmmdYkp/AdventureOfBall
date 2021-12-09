using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    int sayac;
    [Header("Ball Properties")]
    static public Rigidbody Physic;
    public int hiz = 10;

    [Header("Stage Properties")]
    public Text Score;
    public int toplanilacakObjeSayisi;

    [Header("Menu UI")]
    public GameObject FailUI;
    public GameObject FinishMenu;
    public Text StageScore;
    public GameObject joyStick;
    public GameObject pauseButton;
    public GameObject jumpButton;


    public bool yerdemi;
    public float ziplamaHiz = 7.5f;

    bool Fail = false;
    bool Finish = false;


    float yatay;
    float dikey;

    
    void Start()
    {

        //PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name));

        Physic = GetComponent<Rigidbody>();


        //yerdemi = true;

        joyStick.SetActive(true);
        pauseButton.SetActive(true);
        jumpButton.SetActive(true);

         yatay = Input.GetAxisRaw("Horizontal");
         dikey = Input.GetAxisRaw("Vertical");


        //CheckMusicMute.audioSource.mute = false;

        Physic.constraints = RigidbodyConstraints.None;
    }


    private void Update()
    {
        if (Fail)
        {
            FailSettings();
            if (true)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene("menu");
                }
            }
        }
        if (Finish)
        {
            FinishSettings();
        }

    }



    void FixedUpdate()
    {
        Vector3 vec = new Vector3(yatay, 0, dikey);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Physic.AddForce(vec * hiz);
        }


        if (PauseMenu.GamePause)
        {
            Physic.constraints = RigidbodyConstraints.FreezeAll;

        }
        else
        {
            Physic.constraints = RigidbodyConstraints.None;
        }
        
          
            if (Input.GetButton("Jump"))
            {
                Jump();
            }            
        
        
        

    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("yertag") || collision.gameObject.CompareTag("merdiventag") || collision.gameObject.CompareTag("activeWay"))
        {
            yerdemi = true;
        }
        
        if (collision.gameObject.CompareTag("mapdistag"))
        {
            Fail = true;
        }
    }
    
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("yertag") || collision.gameObject.CompareTag("merdiventag") || collision.gameObject.CompareTag("activeWay"))
        {
            yerdemi = false;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("yem") || other.gameObject.CompareTag("gold"))
        {
            other.gameObject.SetActive(false);
            sayac++;
            Score.text = "Score = " + sayac;
        }

        if (other.gameObject.CompareTag("finishtag"))
        {
            Finish = true;
        }

        if (other.CompareTag("dikentag"))
        {
            Fail = true;
        }

        if (other.gameObject.CompareTag("yertag") || other.gameObject.CompareTag("merdiventag") || other.gameObject.CompareTag("activeWay"))
        {
            yerdemi = true;
        }

        if (other.gameObject.CompareTag("jumpRamp"))
        {
            Physic.AddForce(0, 0, -8 , ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Booster"))
        {
            Physic.AddForce(0, 0, 6.5f, ForceMode.Impulse);
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("yertag") || other.gameObject.CompareTag("merdiventag") || other.gameObject.CompareTag("activeWay"))
        {
            yerdemi = false;
        }
    }
    void FailSettings()
    {
        Physic.constraints = RigidbodyConstraints.FreezeAll;
        Score.text = "";
        FailUI.SetActive(true);

        joyStick.SetActive(false);
        pauseButton.SetActive(false);
        jumpButton.SetActive(false);

            
        if (PlayerPrefs.GetFloat("MuteMusic") > 0)
        {
            SoundManager.PlaySound("Fail");
        }

    }

    void FinishSettings()
    {
        Physic.constraints = RigidbodyConstraints.FreezeAll;
        Score.text = "";
        FinishMenu.SetActive(true);
        StageScore.text = "SCORE : " + sayac + "/" + toplanilacakObjeSayisi;
        PlayerPrefs.SetInt("kayit", int.Parse(SceneManager.GetActiveScene().name) + 1);

        joyStick.SetActive(false);
        pauseButton.SetActive(false);
        jumpButton.SetActive(false);

        if (PlayerPrefs.GetFloat("MuteMusic") > 0)
        {
            SoundManager.PlaySound("Success");
        }
    }

    public void Jump()
    {
        if (yerdemi)
        {
            Physic.AddForce(0, ziplamaHiz, 0, ForceMode.Impulse);
        }
    }
}
