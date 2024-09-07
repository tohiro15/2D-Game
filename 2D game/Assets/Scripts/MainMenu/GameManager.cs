using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private string MainMenuScene = "MainMenu";

    public GameObject EscapeMenu;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            OpenEscapeMenu();
        }
    }

    public void OpenEscapeMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        EscapeMenu.SetActive(true);
    }
    public void CancelEscapeMenu()
    {
        Cursor.lockState = CursorLockMode.Locked;
        EscapeMenu.SetActive(false);
    }
    public void ExitGame()
    {
            SceneManager.LoadScene(MainMenuScene);
    }
}
