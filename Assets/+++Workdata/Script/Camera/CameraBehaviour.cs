using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject vcam;

    public GameObject pauseButton;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vcam.SetActive(true);
            pauseButton.SetActive(true);
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            vcam.SetActive(false);
            pauseButton.SetActive(false);
        }
    }

    public IEnumerator TipWait()
    {
        yield return null;
    }
}
