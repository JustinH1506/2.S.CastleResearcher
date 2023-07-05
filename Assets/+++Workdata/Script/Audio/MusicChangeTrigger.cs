using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChangeTrigger : MonoBehaviour
{
    [SerializeField] string parameterName;

    [SerializeField] float parameterValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.SetMusicParameter(parameterName, parameterValue);
        }
    }
}
