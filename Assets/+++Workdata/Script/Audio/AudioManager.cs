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

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);    
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);

        eventInstances.Add(eventInstance);  

        return eventInstance;
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

    public void SetAmbienceParameter(string parameterName, float parametereValue)
    {
        ambienceEventInstance.setParameterByName(parameterName, parametereValue);
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

    public void SetMusicParameter(string parameterName, float parametereValue)
    {
        musicEventInstance.setParameterByName(parameterName, parametereValue);
    }

    private void CleanUp()
    {
        foreach(EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
}
