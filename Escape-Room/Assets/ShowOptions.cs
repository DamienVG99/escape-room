using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShowOptions : MonoBehaviour {

    public string LoadScene;
    public Button StartButton;
    // Use this for initialization
    void Start()
    {
        StartButton.onClick.AddListener(LoadNewScene);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void LoadNewScene()
    {
        SceneManager.LoadScene(LoadScene);
    }
}

