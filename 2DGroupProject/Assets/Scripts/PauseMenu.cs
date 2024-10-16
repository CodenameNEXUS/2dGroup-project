using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    bool pause = true;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Canvas>().enabled = pause;
    }

    // Update is called once per frame
    void Update()
    {
        //If the escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            //display the pause menu
            GetComponent<Canvas>().enabled = true;
            //pause the game
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Resume();
        }
    }
    public void Resume()
    {
        //hide the pause canvas again
        GetComponent<Canvas>().enabled = false;
        //reset the time scale to 1
        Time.timeScale = 1;
    }

    public void RelaodLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("cave");
    }
    public void LVLSelect()
    {
        SceneManager.LoadScene("LVLSelect");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}

