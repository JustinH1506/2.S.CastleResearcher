using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject vcam;

    public GameObject pauseButton;

    /// <summary>
    /// Sets cam active, sets pauseButton active.
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vcam.SetActive(true);

            pauseButton.SetActive(true);
        }
    }

    /// <summary>
    /// Sets cam not active, sets pauseButton not active.
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vcam.SetActive(false);

            pauseButton.SetActive(false);
        }
    }
}
