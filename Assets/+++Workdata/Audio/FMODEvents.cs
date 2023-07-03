using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: SerializeField] public EventReference ambience { get; private set; }
    [field: SerializeField] public EventReference music { get; private set; }

    public static FMODEvents instance { get; private set; }

    /// <summary>
    /// We ask if the instance isn´t null it shall give us a warning and we make this gameObject teh instance.
    /// </summary>
    private void Awake()
    {
        if( instance != null)
        {
            Debug.LogWarning("Found more than one FMODEvents!");
        }
        instance = this;
    }
}
