using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

   
    [SerializeField] GameObject volumeSlider;
    [SerializeField] GameObject panel;
    [SerializeField] float defaultVolume = 0.5f;

    private bool isSliderOpened = false;
    private MusicPlayer musicPlayerRef;





    void Start()
    {
        PlayerPrefsController.SetMasterVolume(defaultVolume);
        if (volumeSlider)
        {
            volumeSlider.GetComponent<Slider>().value = PlayerPrefsController.GetMasterVolume();
        }

    }

    void Update()
    {
         musicPlayerRef = FindObjectOfType<MusicPlayer>();
        if (musicPlayerRef && volumeSlider)
        {
            Debug.Log("find == "+ musicPlayerRef);
            musicPlayerRef.SetVolume(volumeSlider.GetComponent<Slider>().value);
        }
        else
        {
            Debug.LogWarning("no music player found... did you start from splesh screen");
        }
    
    
    }


    public void SettingButtonOnClick()
    {
        Debug.Log("Setting button is pressed");
        panel.GetComponent<Animator>().SetTrigger("pop");
    }

   
    public void OpenFaceBookPage()
    {
        Application.OpenURL("https://www.facebook.com/Yesicbap-107713864201843/?view_public_for=107713864201843");
    }


    public void ShareWithFriends()
    {
        Debug.Log("This will be implemented in the future");
    
    }




    public void OnPressedOnVolumnButton()
    {
        if (!isSliderOpened)
        {
             volumeSlider.SetActive(true);
            Debug.Log("Slider get opened");
            isSliderOpened = true;

        }
        else 
        {
            volumeSlider.SetActive(false);
            Debug.Log("Slider get closed");
            isSliderOpened = false;
        }
        

    }




    public void ToggleButtonChanged(bool IsOn)
    {
         print(IsOn);
        // Debug.LogError("Current Situation = "+ IsOn);

        if (musicPlayerRef)
        {
                if (IsOn)
                {
                    musicPlayerRef.GetComponent<AudioSource>().Play();
                }
                else
                {
                    musicPlayerRef.GetComponent<AudioSource>().Stop();
                }
        }
        else
        {
            Debug.LogWarning("music player not found...");
        }




    }




}
