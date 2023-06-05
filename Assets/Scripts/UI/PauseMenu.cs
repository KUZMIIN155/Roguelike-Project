using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector]
    public bool IsPaused = false;
    [HideInInspector]
    public bool IsTrue = false;

    public GameObject buttonMenu;
    public GameObject pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        if(IsTrue == false)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
        }
    }

    void Pause()
    {
        if(IsTrue == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
        }
    }

    public void ShowPanel(GameObject obj)
    {
        if(IsTrue == false)
        {
            obj.SetActive(true);
            Time.timeScale = 0f;
            IsPaused = true;
            buttonMenu.SetActive(false);
        }
    }

    public void HidePanel(GameObject obj)
    {
        if(IsTrue == false)
        {
            obj.SetActive(false);
            Time.timeScale = 1f;
            IsPaused = false;
            buttonMenu.SetActive(true);
        }
    }

    public void ExitMenu(int exit)
    {
        if(IsTrue == false)
        {
            exit = 0;
            Time.timeScale = 1f;
            IsPaused = false;
            SceneManager.LoadScene(exit);
        }
    }
}
