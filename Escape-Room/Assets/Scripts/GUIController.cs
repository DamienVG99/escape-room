using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {

    public static bool Paused = false;
    public GameObject pauseMenuUI;
    public Button resumeButton;
    public Button exitButton;
    private GameObject Mouse;
	// Use this for initialization
	void Start () {
    }
    void OnGUI()
    {
        resumeButton.onClick.AddListener(Resume);
        //exitButton.onClick.AddListener(Exit);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                Resume();
            }
            else if(!Paused)
            {
                Pause();
            }
        }
        if (Paused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Pause()
    {
        if (Paused)
            return;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    void Resume()
    {
        if (!Paused)
            return;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}
