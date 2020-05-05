﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); 

    }

    public void QuitGame()
    {
        Application.Quit(); 
    }
}
