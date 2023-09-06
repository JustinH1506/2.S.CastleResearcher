using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;

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

        eventInstances = new List<EventInstance>();
    }

    /// <summary>
    /// Playy the PlayOneShot sound.
    /// </summary>
    /// <param name="sound"></param>
    /// <param name="worldPos"></param>
    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);    
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventReference"></param>
    /// <returns></returns>
    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);

        eventInstances.Add(eventInstance);  

        return eventInstance;
    }

    /// <summary>
    /// Start the Music, startMusic and Ambienece.
    /// </summary>
    private void Start()
    {
        InitializeMusic(FMODEvents.instance.music);

        InitializeMusic(FMODEvents.instance.startMusic);

        InitializedAmbience(FMODEvents.instance.ambience);
    }

    /// <summary>
    /// Starting the ambience sound.
    /// </summary>
    /// <param name="ambienceEventReference"></param>
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
    /// Stoping the sounds when entering other scenes.
    /// </summary>
    private void CleanUp()
    {
        foreach(EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }


    /// <summary>
    /// Calling CleanUp method.
    /// </summary>
    private void OnDestroy()
    {
        CleanUp();
    }
}
