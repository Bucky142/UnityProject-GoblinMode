using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;


    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeSelf == true)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;


    }

    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        UnityEngine.Cursor.visible = true;
    }

    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
