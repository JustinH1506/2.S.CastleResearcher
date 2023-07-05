using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    public GameObject credits;

    public GameObject buttons;

    public GameObject audioOptions;


    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        audioOptions.SetActive(true);

        buttons.SetActive(false);
    }

    public void Credits()
    {
        credits.SetActive(true);

        buttons.SetActive(false);
    }

    public void BackFromCredits()
    {
        credits.SetActive(false);

        buttons.SetActive(true);
    }

    public void BackFromAudio()
    {
        audioOptions.SetActive(false);

        buttons.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        buttons.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        buttons.SetActive(false);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Back()
    {
        buttons.SetActive(false);
    }
}
