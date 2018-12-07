using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public Button saveButton;
    public GameObject player;
    public new GameObject camera;

    void Start()
    {
        Debug.Log("Start!");
        saveButton.onClick.AddListener(SavePlayerData);
    }

    void Update()
    {
        
    }

    public void SavePlayerData()
    {        
        PlayerPrefs.SetFloat("PositionX", player.transform.position.x);
        PlayerPrefs.SetFloat("PositionY", player.transform.position.y);
        PlayerPrefs.SetFloat("PositionZ", player.transform.position.z);

        PlayerPrefs.SetFloat("PlayerRotation", player.transform.eulerAngles.y);
        PlayerPrefs.SetFloat("CameraRotation", camera.transform.eulerAngles.x);

        PlayerPrefs.Save();
        Debug.Log("Saved Position!");
    }
}
