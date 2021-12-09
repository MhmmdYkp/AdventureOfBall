using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public int level;
    
    public Button [] levelButtons;
    int levelReached;
    private void Start()
    {
         levelReached = PlayerPrefs.GetInt("kayit",1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i+1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    private void Update()
    {
        levelReached = PlayerPrefs.GetInt("kayit");
    }

    public void Select(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
