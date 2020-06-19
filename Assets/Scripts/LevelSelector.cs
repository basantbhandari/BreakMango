using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    public Sprite lockSprite;
    public Sprite unlockSprite;
    public Button[] allLevelButtons;

    private int maximumCurrentBuildIndex = 0;




    // todo initially setting all the level ui 
    void Awake()
    {
       
        for (int i = 0; i < allLevelButtons.Length; i++)
        {
            if (i < PlayerPrefsController.GetLevelReached())
            {
                allLevelButtons[i].image.sprite = unlockSprite;
                allLevelButtons[i].interactable = true;
                maximumCurrentBuildIndex = (i + 1);
            }
            else
            {
                allLevelButtons[i].image.sprite = lockSprite;
                allLevelButtons[i].interactable = false;
            }
        }
    }



    // Updating all the level are unlocked
    void Update()
    {
        for (int i = 0; i < allLevelButtons.Length; i++)
        {
            if (i < PlayerPrefsController.GetLevelReached())
            {
                allLevelButtons[i].image.sprite = unlockSprite;
                allLevelButtons[i].interactable = true;
                maximumCurrentBuildIndex = (i + 1);
            }
            else
            {
                allLevelButtons[i].image.sprite = lockSprite;
                allLevelButtons[i].interactable = false;
            }
        }
    }




    public void Select( string btnLevelName)
    {
        Debug.Log("Level Selector :: Load level = " + btnLevelName);
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        if (levelLoader)
        {
            levelLoader.LoadSendLevel(btnLevelName, maximumCurrentBuildIndex);
        }
        else
        {
            Debug.LogError("Level Selector :: level loader object is not present on this scene");
        }


    }










}
