using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class volumeController : MonoBehaviour {

    // Use this for initialization
    public float defaultVolumeLevel = 0.5f;
    

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
}
