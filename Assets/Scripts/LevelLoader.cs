using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }



    public void LoadLevel_First()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void ApplicationQuit()
    {
        Application.Quit();
    }




}
