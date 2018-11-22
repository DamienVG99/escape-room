using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIController : MonoBehaviour {

    public Text Textbox;
    public static bool Paused = false;
    public GameObject pauseMenuUI;
    public Button resumeButton;
    public Button exitButton;
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
        else
            UpdatePosition();
    }

    void UpdatePosition()
    {
        Textbox.text = transform.position.ToString();
    }

    void Pause()
    {
        if (Paused)
            return;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
        gameObject.GetComponent<ViewController>().enabled = false;
    }

    void Resume()
    {
        if (!Paused)
            return;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        gameObject.GetComponent<ViewController>().enabled = true;
        gameObject.GetComponent<ViewController>().Center();
    }

    void Exit()
    {
        SceneManager.LoadScene(gameObject.GetComponent<StartGame>().UnLoadScene);
        SceneManager.UnloadScene(gameObject.GetComponent<StartGame>().LoadScene);
    }

}
