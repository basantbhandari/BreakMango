using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string LEVEL_REACHED_KEY = "level reached";

    const float MIN_VOLUME = 0f;
    const float MAX_VOLUME = 1f;

    const int MIN_LEVEL_REACHED = 1;
    const int MAX_LEVEL_REACHED = 21;

    public static void SetMasterVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            Debug.Log("PlayerPrefsController ::master volume set to " + volume);
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else 
        {
            Debug.LogError("PlayerPrefsController :: Master volume is out of range");
        }
    }


    public static float GetMasterVolume()
    {
        float vol = PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
        Debug.Log("PlayerPrefsController ::master volume get to " + vol);
        return vol;
    }


    public static void SetLevelReached(int levelReached)
    {
        if (levelReached >= MIN_LEVEL_REACHED && levelReached <= MAX_LEVEL_REACHED)
        {
            Debug.Log("PlayerPrefsController :: level reached set to " + levelReached);
            PlayerPrefs.SetInt(LEVEL_REACHED_KEY, levelReached);
        }
        else
        {
            Debug.LogError("PlayerPrefsController :: level reached is out of range " + levelReached);
        }
    }


    public static int GetLevelReached()
    {
        int reachedLevel = PlayerPrefs.GetInt(LEVEL_REACHED_KEY);
        Debug.Log("PlayerPrefsController ::reached level get to " + reachedLevel);
        return reachedLevel;
    }







}
