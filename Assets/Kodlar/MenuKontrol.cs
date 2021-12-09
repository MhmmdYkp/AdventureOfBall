using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuKontrol : MonoBehaviour
{

    Animator CameraObject;
    public GameObject Cam;

    public void Start()
    {
        CameraObject = transform.GetComponent<Animator>();
    }


    public void OyunaBasla()
    {
        //int kayitlilevel = PlayerPrefs.GetInt("kayit");
        /*
        if (kayitlilevel == 0)
        {
            SceneManager.LoadScene(kayitlilevel + 1);
        }
        else
        {
            SceneManager.LoadScene(kayitlilevel);
        }
        */

        SceneManager.LoadScene("SelectLevel");
    }
    public void OyundanCik()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

        #else
		Application.Quit();

        #endif
    }

    public void Position2()
    {
        CameraObject.SetFloat("Animasyon", 1);        
    }

    public void Position1()
    {
        CameraObject.SetFloat("Animasyon", 0);        
    }


}
