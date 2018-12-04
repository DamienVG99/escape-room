using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ShowOptions : MonoBehaviour {

    public string LoadScene;
    public Button StartButton;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void LoadNewScene()
    {
        SceneManager.LoadScene("optionScreen");
    }
}

