using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class startMenu : MonoBehaviour {

    // Use this for initialization


    public float defaultVolumeLevel = -3f;
    public float defaultQualitySetting = 3f;
    public Boolean defaultFullscreenToggle = true;

    public AudioMixer mainAudiomixer;
    public Resolution[] resolutions;
    void Start () {
        if (PlayerPrefs.GetInt("savedSettingsData") == 1)
        {
            mainAudiomixer.SetFloat("mainVolume", PlayerPrefs.GetInt("currentVolume"));
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("currentQualitySetting"));
            setFullScreen(Convert.ToBoolean(PlayerPrefs.GetInt("currentFullscreenSetting")));
            setScreenResolution(PlayerPrefs.GetInt("currentResolution"));
        }
        else
        {
            storeDefaultSettings();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startMainGame()
    {
        Application.LoadLevel("MainGame");
    }

    public void loadOptionScreen()
    {
        Application.LoadLevel("OptionScreen");
    }

    public void storeDefaultSettings()
    {

        PlayerPrefs.SetInt("savedSettingsData", 1);
        PlayerPrefs.SetInt("currentVolume", Convert.ToInt32(defaultVolumeLevel));
        PlayerPrefs.SetInt("currentQualitySetting", Convert.ToInt32(defaultQualitySetting));
        PlayerPrefs.SetInt("currentFullscreenSetting", Convert.ToInt32(defaultFullscreenToggle));
        setFullScreen(defaultFullscreenToggle);

        int resolutionIndex = detectResolution();
        PlayerPrefs.SetInt("currentResolution", resolutionIndex);
        setScreenResolution(resolutionIndex);

        mainAudiomixer.SetFloat("mainVolume", defaultVolumeLevel);
        QualitySettings.SetQualityLevel(Convert.ToInt32(defaultQualitySetting));
    }

    public void setFullScreen(Boolean value)
    {
        Screen.fullScreen = value;
        if (Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        setScreenResolution(PlayerPrefs.GetInt("currentResolution"));
    }

    public void setScreenResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public int detectResolution()
    {
        resolutions = Screen.resolutions;


        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        return currentResolutionIndex;
    }
}
