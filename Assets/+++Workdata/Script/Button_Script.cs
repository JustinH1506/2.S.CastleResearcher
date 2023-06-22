using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Script : MonoBehaviour
{
    public GameObject credits;

    public GameObject buttons;
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Options()
    {

    }

    public void Credits()
    {
        credits.SetActive(true);

        buttons.SetActive(false);
    }

    public void BackToButtons()
    {
        credits.SetActive(false);

        buttons.SetActive(true);
    }
}
