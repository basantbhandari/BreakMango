using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    private AudioSource audioSource;
    void Start()
    {
        // making singleton
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();
        
    }

    public void SetVolume(float volume) 
    
    {
        audioSource.volume = volume;
        PlayerPrefsController.SetMasterVolume(volume);
    }




}
