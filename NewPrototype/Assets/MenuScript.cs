using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MenuScript : MonoBehaviour
{
    public GameObject menu;
    bool paused = false;

    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            Paused();
        }
        else
        {

            if (Input.GetKeyDown(KeyCode.Escape) && paused)
            {
                Play();
            }

        }

        if (Input.GetKeyDown(KeyCode.Q) && paused)
        {
            SceneManager.LoadScene(0);
        }
        

    }

    public void Paused()
    {
        paused = true; 
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Play()
    {
        paused = false;
        menu.SetActive(false);
        Time.timeScale = 1; 
    }
}
