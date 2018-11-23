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
    public Resolution resolutionDropdown;

    Resolution[] resolutions;


    public void start()
    {
        resolutions = Screen.resolutions;
        //resolutionDropdown.cl
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
    }

    public void SetDefaultSettings ()
    {
        GameObject.Find("volumeDisplay").GetComponent<Slider>().value = defaultVolumeLevel;
        GameObject.Find("graphicsDisplay").GetComponent<Slider>().value = 3f;
        GameObject.Find("graphicsDisplay").GetComponentInChildren<Text>().text = convertQualitySetting(3);
        GameObject.Find("fullscreenToggle").GetComponent<Toggle>().isOn = defaultFullscreenToggle;  
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
}
