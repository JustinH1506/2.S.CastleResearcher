using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Dynamic;

public class AudioManager : MonoBehaviour
{
    private EventInstance musicEventInstance;

    private EventInstance ambienceEventInstance;

    public static AudioManager instance { get; private set; }    

    /// <summary>
    /// We ask if the instance isn´t null it shall give us a warning and we make this gameObject the instance.
    /// </summary>
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Found more than one AudioManager");
        }
        instance = this;
    }

    /// <summary>
    /// We call the InitializeMusic method.
    /// </summary>
    private void Start()
    {
        InitializeMusic(FMODEvents.instance.music);

        InitializedAmbience(FMODEvents.instance.ambience);
    }

    private void InitializedAmbience(EventReference ambienceEventReference)
    {
        ambienceEventInstance = CreateInstance(ambienceEventReference);
        ambienceEventInstance.start();
    }

    /// <summary>
    /// We call the CreateInstance Method to make our musicEventIntsance to this and start it at the start method.
    /// </summary>
    /// <param name="musicEventReference"></param>
    private void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance = CreateInstance(musicEventReference);
        musicEventInstance.start();
    }


    /// <summary>
    /// We make the CreateInstance Method.
    /// </summary>
    /// <param name="eventReference"></param>
    /// <returns></returns>
    private EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }
}
