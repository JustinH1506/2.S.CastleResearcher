using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera_Switch : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera vcam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            vcam.m_Priority = +2;
        }
    }
}
