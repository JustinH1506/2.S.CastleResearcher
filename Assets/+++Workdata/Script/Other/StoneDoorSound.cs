using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDoorSound : MonoBehaviour
{
    public void Sound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.stoneDoor, transform.position);
    }
}
