using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSetting : MonoBehaviour
{
    [Header("TEXTURE SETTINGS")]
    public GameObject dropDown;

    public GameObject Top;
    private MeshRenderer ball;

    private int dropDownValue;

    public Material m1,m2,m3,m4,m5,m6,m7,m8,m9,m10;


    private void Start()
    {
        
        ball = Top.GetComponent<MeshRenderer>();
    }

    public void DropDown()
    {
        dropDownValue = dropDown.GetComponent<Dropdown>().value;

        PlayerPrefs.SetInt("BallColor", dropDownValue);
        
        if (PlayerPrefs.GetInt("BallColor") == 0)
        {
            ball.material = m1;
        }

        if (PlayerPrefs.GetInt("BallColor") == 1)
        {
            ball.material = m2;

        }
        if (PlayerPrefs.GetInt("BallColor") == 2)
        {
            ball.material = m3;
        }
        if (PlayerPrefs.GetInt("BallColor") == 3)
        {
            ball.material = m4;
        }
        if (PlayerPrefs.GetInt("BallColor") == 4)
        {
            ball.material = m5;
        }
        if (PlayerPrefs.GetInt("BallColor") == 5)
        {
            ball.material = m6;
        }
        if (PlayerPrefs.GetInt("BallColor") == 6)
        {
            ball.material = m7;
        }
        if (PlayerPrefs.GetInt("BallColor") == 7)
        {
            ball.material = m8;
        }
        if (PlayerPrefs.GetInt("BallColor") == 8)
        {
            ball.material = m9;
        }
        if (PlayerPrefs.GetInt("BallColor") == 9)
        {
            ball.material = m10;
        }
        
    }
}
