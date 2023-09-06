using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    public GameObject credits;

    public GameObject buttons;

    public GameObject audioOptions;

    public PlayerMovement playerMovement;

    /// <summary>
    /// Load scene 1, plays clickButton sound.
    /// </summary>
    public void GameStart()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);

        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Quiting the Game, plays clickButton sound.
    /// </summary>
    public void Quit()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);

        Application.Quit();
    }

    /// <summary>
    /// audioOptions gets active, buttons get deactivated, plays clickButton sound.
    /// </summary>
    public void Options()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);

        audioOptions.SetActive(true);

        buttons.SetActive(false);
    }

    /// <summary>
    /// credits get active, buttons get false, plays clickButton sound.
    /// </summary>
    public void Credits()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);

        Color color = new Color (255,255, 255, 150);

        credits.SetActive(true);

        buttons.SetActive(false);
    }

    /// <summary>
    /// Credits get fals, buttons get true, plays clickButton sound.
    /// </summary>
    public void BackFromCredits()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);

        credits.SetActive(false);

        buttons.SetActive(true);
    }

    /// <summary>
    /// audioOptions get false, buttons get true, plays clickButton sound.
    /// </summary>
    public void BackFromAudio()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);

        audioOptions.SetActive(false);

        buttons.SetActive(true);
    }

    /// <summary>
    /// Stops time, buttons get true, plays clickButton sound.
    /// </summary>
    public void PauseGame()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);

        Time.timeScale = 0;

        buttons.SetActive(true);
    }

    /// <summary>
    /// time starts, buttons get false, plays clickButton sound.
    /// </summary>
    public void Resume()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);

        Time.timeScale = 1;

        buttons.SetActive(false);
    }

    /// <summary>
    /// Time starts, load scene 0, plays clickButton sound.
    /// </summary>
    public void Exit()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);

        Time.timeScale = 1;

        SceneManager.LoadScene(0);
    }
}