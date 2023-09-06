using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar_Items : MonoBehaviour
{
    [SerializeField] ItemBehaviour itemBehaviour;
    [SerializeField] ItemManager itemManager;

    public bool isActive;
    public bool isUsed;

    /// <summary>
    /// gameObject gets true, isActive gets true.
    /// </summary>
    public void CheckInventar()
    {
        gameObject.SetActive(true);
        isActive = true;
    }

    /// <summary>
    /// gameObject gets false, itemManager gets false
    /// </summary>
    public void CheckStatues()
    {
        gameObject.SetActive(false);

        itemManager.isActive = false;
    }
}