using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip  Fail, Success,ActiveButton;
    static AudioSource audioSrc;


    void Start()
    {        
        Success = Resources.Load<AudioClip>("Success");
        Fail = Resources.Load<AudioClip>("Fail");
        ActiveButton = Resources.Load<AudioClip>("ActiveButton");

        audioSrc = GetComponent<AudioSource>();

        audioSrc.spatialBlend = 0;
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "Success":
                audioSrc.PlayOneShot(Success);
                break;

            case "Fail":
                audioSrc.PlayOneShot(Fail);
                break;

            case "ActiveButton":
                audioSrc.PlayOneShot(ActiveButton);
                break;

            default:
                break;
        }
    }
}
