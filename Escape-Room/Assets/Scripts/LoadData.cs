using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    public Button loadButton;
    public GameObject player;
    public new GameObject camera;

    public float CharacterXPosition;
    public float CharacterYPosition;
    public float CharacterZPosition;

    public float CharacterYRotation;
    public float CameraXRotation;

    void Start ()
    {
        loadButton.onClick.AddListener(LoadPlayerData);        
    }

    void Update()
    {
        
    }

    public void LoadPlayerData()
    {
        CharacterXPosition = PlayerPrefs.GetFloat("PositionX");
        CharacterYPosition = PlayerPrefs.GetFloat("PositionY");
        CharacterZPosition = PlayerPrefs.GetFloat("PositionZ");

        CharacterYRotation = PlayerPrefs.GetFloat("PlayerRotation");
        CameraXRotation = PlayerPrefs.GetFloat("CameraRotation");

        player.transform.position = new Vector3(CharacterXPosition, CharacterYPosition, CharacterZPosition);
        player.transform.rotation = Quaternion.Euler(0, CharacterYRotation, 0);
        camera.transform.rotation = Quaternion.Euler(CameraXRotation, 0, 0);
        Debug.Log("Loaded Position!");
    }
}