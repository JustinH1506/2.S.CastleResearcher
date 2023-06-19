using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bridge_Collision : MonoBehaviour
{
    public GameObject bridge;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bridge_breaker"))
        {
            bridge.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Scene_Switch"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
