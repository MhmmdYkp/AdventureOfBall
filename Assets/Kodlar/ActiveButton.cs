using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButton : MonoBehaviour
{
    Animator Button;

    [Header("GameObjects")]
    public GameObject MainCamera;
    public GameObject ActiveCamera;

    static public string buttonString = "Button";
    static public int buttonInt = 0;
    void Start()
    {

        Button = transform.GetComponent<Animator>();

        buttonInt = 0;
        MainCamera.SetActive(true);
        ActiveCamera.SetActive(false);
    }

     void OnTriggerEnter(Collider other)
    {
        if (buttonInt < 5)
        {
            buttonInt = 10;
            if (other.gameObject.CompareTag("top"))
            {
                Button.SetInteger(buttonString, buttonInt);
                SoundManager.PlaySound("ActiveButton");
                StartCoroutine(SwitchCameras());
            }
        }       
    }

    IEnumerator SwitchCameras()
    {
        MainCamera.SetActive(false);
        ActiveCamera.SetActive(true);

        yield return new WaitForSeconds(5);

        MainCamera.SetActive(true);
        ActiveCamera.SetActive(false);
    }
}