using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour
{
    FMOD.Studio.EventInstance seTestEvent;

    FMOD.Studio.Bus master;
    FMOD.Studio.Bus sFX;
    FMOD.Studio.Bus music;
    float MusicVolume = 0.5f;
    float SFXVolume = 0.5f;
    float MasterVolume = 1f;


    /// <summary>
    /// Getting the busses from FMOD
    /// </summary>
    void Awake()
    {
        music = FMODUnity.RuntimeManager.GetBus("bus:/Master/Music");
        sFX = FMODUnity.RuntimeManager.GetBus("bus:/Master/SFX");
        master = FMODUnity.RuntimeManager.GetBus("bus:/Master");
    }

    /// <summary>
    /// Seting the float as Volume to the busses
    /// </summary>
    void Update()
    {
        music.setVolume(MusicVolume);
        sFX.setVolume(SFXVolume);
        master.setVolume(MasterVolume);
    }


    /// <summary>
    /// Method to Change the Volume based on the new value
    /// </summary>
    /// <param name="newMasterVolume"></param>
    public void MasterVolumeLevel(float newMasterVolume)
    {
        MasterVolume = newMasterVolume;
    }

    /// <summary>
    /// Method to Change the Volume based on the new value
    /// </summary>
    /// <param name="newMasterVolume"></param>
    public void MusicVolumeLevel(float newMusicVolume)
    {
        MusicVolume = newMusicVolume;
    }

    /// <summary>
    /// Method to Change the Volume based on the new value
    /// </summary>
    /// <param name="newMasterVolume"></param>
    public void SFXVolumeLevel(float newSFXVolume)
    {
        SFXVolume = newSFXVolume;
    }
}