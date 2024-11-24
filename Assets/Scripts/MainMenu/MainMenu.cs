using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuCanvas;

    public void StartNewGame()
    { 
        MainMenuCanvas.SetActive(false);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
