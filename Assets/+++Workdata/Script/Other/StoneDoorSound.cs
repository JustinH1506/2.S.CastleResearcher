using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDoorSound : MonoBehaviour
{

    /// <summary>
    /// Plays stoneDoor sound.
    /// </summary>
    public void Sound()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.stoneDoor, transform.position);
    }
}
