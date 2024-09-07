using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private string MainMenuScene = "MainMenu";

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(MainMenuScene);
        }
    }
}
