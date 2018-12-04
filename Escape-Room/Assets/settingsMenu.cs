using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class settingsMenu : MonoBehaviour {

    public float defaultVolumeLevel = -3f;
    public float defaultQualitySetting = 3f;
    public Boolean defaultFullscreenToggle = true;

    public AudioMixer mainAudiomixer;
    public Dropdown resolutionDropdown;
    public Resolution[] resolutions;

    void Start()
    {
        contstructResolutionDropdown();


        if (PlayerPrefs.GetInt("savedSettingsData") == 1)
        {
            GameObject.Find("volumeDisplay").GetComponent<Slider>().value = PlayerPrefs.GetInt("currentVolume"); ;
            GameObject.Find("graphicsDisplay").GetComponent<Slider>().value = PlayerPrefs.GetInt("currentQualitySetting");
            GameObject.Find("graphicsDisplay").GetComponentInChildren<Text>().text = convertQualitySetting(PlayerPrefs.GetInt("currentQualitySetting"));
            GameObject.Find("fullscreenToggle").GetComponent<Toggle>().isOn = Convert.ToBoolean(PlayerPrefs.GetInt("currentFullscreenSetting"));
            GameObject.Find("resolutionDropdown").GetComponent<Dropdown>().value = PlayerPrefs.GetInt("currentResolution");

            mainAudiomixer.SetFloat("mainVolume", PlayerPrefs.GetInt("currentVolume"));
            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("currentQualitySetting"));
            setFullScreen(Convert.ToBoolean(PlayerPrefs.GetInt("currentFullscreenSetting")));
            setScreenResolution(PlayerPrefs.GetInt("currentResolution"));

        }
        else
        {
            setDefaultSettings();
            storeSettings();
        }
    }

    public void volumeDown()
    {
        GameObject volumeDisplay = GameObject.Find("volumeDisplay");
        float currentVolume = volumeDisplay.GetComponent<Slider>().value;
        currentVolume--;
        volumeDisplay.GetComponent<Slider>().value = currentVolume;
    }

    public void volumeUp()
    {
        GameObject volumeDisplay = GameObject.Find("volumeDisplay");
        float currentVolume = volumeDisplay.GetComponent<Slider>().value;
        currentVolume++;
        volumeDisplay.GetComponent<Slider>().value = currentVolume;
    }

    public void graphicsDown()
    {
        GameObject graphicsDisplay = GameObject.Find("graphicsDisplay");
        float currentgraphics = graphicsDisplay.GetComponent<Slider>().value;
        if (!(graphicsDisplay.GetComponent<Slider>().value == graphicsDisplay.GetComponent<Slider>().minValue))
        {
            currentgraphics--;
        }
        graphicsDisplay.GetComponent<Slider>().value = currentgraphics;
        graphicsDisplay.GetComponentInChildren<Text>().text = convertQualitySetting(currentgraphics);
    }

    public void graphicsUp()
    {
        GameObject graphicsDisplay = GameObject.Find("graphicsDisplay");
        float currentgraphics = graphicsDisplay.GetComponent<Slider>().value;
        if(!(graphicsDisplay.GetComponent<Slider>().value == graphicsDisplay.GetComponent<Slider>().maxValue))
        {
            currentgraphics++;
        }
        graphicsDisplay.GetComponent<Slider>().value = currentgraphics;
        graphicsDisplay.GetComponentInChildren < Text >().text = convertQualitySetting(currentgraphics);

    }

    public void storeSettings()
    {
        GameObject volumeDisplay = GameObject.Find("volumeDisplay");
        float currentVolume = volumeDisplay.GetComponent<Slider>().value;
        currentVolume = currentVolume * 10;
        mainAudiomixer.SetFloat("mainVolume", currentVolume );

        GameObject graphicsDisplay = GameObject.Find("graphicsDisplay");
        int qualitySettings = Convert.ToInt32(graphicsDisplay.GetComponent<Slider>().value);
        QualitySettings.SetQualityLevel(qualitySettings);

        Screen.fullScreen = GameObject.Find("fullscreenToggle").GetComponent<Toggle>().isOn;

        PlayerPrefs.SetInt("savedSettingsData", 1);
        PlayerPrefs.SetInt("currentVolume", Convert.ToInt32(currentVolume));
        PlayerPrefs.SetInt("currentQualitySetting",qualitySettings);
        PlayerPrefs.SetInt("currentFullscreenSetting", Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetInt("currentResolution", resolutionDropdown.value);

    }

    public void setDefaultSettings ()
    {
        GameObject.Find("volumeDisplay").GetComponent<Slider>().value = Convert.ToInt32(defaultVolumeLevel);
        GameObject.Find("graphicsDisplay").GetComponent<Slider>().value = 3f;
        GameObject.Find("graphicsDisplay").GetComponentInChildren<Text>().text = convertQualitySetting(3);
        GameObject.Find("fullscreenToggle").GetComponent<Toggle>().isOn = defaultFullscreenToggle;
        setFullScreen(defaultFullscreenToggle);
        int resolutionIndex = contstructResolutionDropdown();
        setScreenResolution(resolutionIndex);
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
        setScreenResolution(resolutionDropdown.value);
    }

    public string convertQualitySetting(double input)
    {
        string output = "";
        int value = Convert.ToInt32(input);
        switch (value)
        {
            case 0:
                 output = "Ultra low";
                break;
            case 1:
                output = "Low";
                break;
            case 2:
                output = "Medium";
                break;
            case 3:
                output = "High";
                break;
            case 4:
                output = "Very high";
                break;
            case 5:
                output = "Ultra";
                break;
        }
        return output;
    }

    public void setScreenResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public int contstructResolutionDropdown()
    {
        resolutionDropdown = GameObject.Find("resolutionDropdown").GetComponent<Dropdown>();
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();


        List<string> options = new List<string>();
    int currentResolutionIndex = 0;

        for (int i = 0; i<resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
    options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        return currentResolutionIndex;
    }

    public void returnStartScreen()
    {
        Application.LoadLevel("StartScreen");
    }
}
