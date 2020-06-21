using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

   
    [SerializeField] GameObject volumeSlider;
    [SerializeField] GameObject panel;
    [SerializeField] float defaultVolume = 0f;

    private bool isSliderOpened = false;
    private MusicPlayer musicPlayerRef;





    void Start()
    {
        InitialSettingOfDefaultVolumeValue();
    }


    void Update()
    {
        UpdatingMusicVolumeLevelAccordingToVolumeSliderInput();
    }

    private void UpdatingMusicVolumeLevelAccordingToVolumeSliderInput()
    {
        musicPlayerRef = FindObjectOfType<MusicPlayer>();
        if (musicPlayerRef && volumeSlider)
        {
            Debug.Log("Menu Manager:: find == " + musicPlayerRef + " and " + volumeSlider);
            musicPlayerRef.SetVolume(volumeSlider.GetComponent<Slider>().value);
        }
        else
        {
            Debug.LogError("no music player found... did you start from splesh screen");
        }
    }

    private void InitialSettingOfDefaultVolumeValue()
    {
        PlayerPrefsController.SetMasterVolume(defaultVolume);
        if (volumeSlider)
        {
            volumeSlider.GetComponent<Slider>().value = PlayerPrefsController.GetMasterVolume();
        }
    }


    public void SettingButtonOnClick()
    {
        Debug.Log(" Menu Manager:: Setting button is pressed");
        panel.GetComponent<Animator>().SetTrigger("pop");
        if (isSliderOpened) 
        {
            volumeSlider.SetActive(false);
            Debug.Log("Slider get closed");
            isSliderOpened = false;
        }
    }

   
    public void OpenFaceBookPage()
    {
        Application.OpenURL("https://www.facebook.com/Yesicbap-107713864201843/?view_public_for=107713864201843");
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
            Debug.LogError("Menu Manager::music player not found...");
        }

    }





}
