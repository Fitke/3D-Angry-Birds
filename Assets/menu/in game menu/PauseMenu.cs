using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject cannon;
    public GameObject player;
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject OptionsPauseMenuUI;
    public GameObject PlayerUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        Cursor.visible = false;
        player.GetComponent<CameraScript>().enabled = true;
        cannon.GetComponent<Cannon>().enabled = true;
        pauseMenuUI.SetActive(false);
        OptionsPauseMenuUI.SetActive(false);
        PlayerUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        Cursor.visible = true;
        player.GetComponent<CameraScript>().enabled = false;
        cannon.GetComponent<Cannon>().enabled = false;
        PlayerUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Cursor.visible = true;
        PlayerUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
