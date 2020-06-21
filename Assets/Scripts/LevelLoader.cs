using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    [SerializeField] GameObject gameCompletionCanvas;


    public void LoadNextLevel()
    {

        int rl = SceneManager.GetActiveScene().buildIndex + 1;
        if (rl > 21) {
            gameCompletionCanvas.SetActive(true);
        } else
        {
            PlayerPrefsController.SetLevelReached(rl);
            SceneManager.LoadScene(rl);
        }
          
    }

    public void LoadCurrentReachedLevel()
    {
        int currentReLevel = PlayerPrefsController.GetLevelReached();
        SceneManager.LoadScene(currentReLevel);
    }


    public void ResetTheGame()
    {

        PlayerPrefsController.SetLevelReached(1);
        SceneManager.LoadScene(1);

    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }


    // for buttons on level selection menu
    public void LoadSendLevel(string levelName, int currentLevelIndex)
    {
        PlayerPrefsController.SetLevelReached(currentLevelIndex);
        SceneManager.LoadScene(levelName);
    }


    public void LoadLevel_First()
    {
        PlayerPrefsController.SetLevelReached(1);
        SceneManager.LoadScene(1);
    }

    public void LoadCurrentLevel()
    {
        int currLevIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefsController.SetLevelReached(currLevIndex);
        SceneManager.LoadScene(currLevIndex);
    }


    public void ApplicationQuit()
    {
        Application.Quit();
       
    }
    public void LoadLevelSelectorScene()
    {
        int currLevR = PlayerPrefsController.GetLevelReached();
        Debug.Log("LevelLoader :: current level number = "+ currLevR);
        SceneManager.LoadScene("LevelSelection");
    }




}
