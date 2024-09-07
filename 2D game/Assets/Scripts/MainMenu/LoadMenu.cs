using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject LoadingMenu;

    public AudioSource BackgroundMusic;

    private string NewGameScene = "SampleScene";
    public void Loading()
    {
        BackgroundMusic.Stop();

        MainMenu.SetActive(false);
        LoadingMenu.SetActive(true);

        StartCoroutine(LoadAsync());
    }
    IEnumerator LoadAsync()
    {
        AsyncOperation loadAsync = SceneManager.LoadSceneAsync(NewGameScene);

        loadAsync.allowSceneActivation = false;

        while(!loadAsync.isDone)
        {
            if(loadAsync.progress >= .9f && !loadAsync.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                loadAsync.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
