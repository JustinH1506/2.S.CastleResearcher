using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventar_Items : MonoBehaviour
{
    [SerializeField] ItemBehaviour itemBehaviour;
    [SerializeField] ItemManager itemManager;

    public bool isActive;
    public bool isUsed;

    public void CheckInventar()
    {
        gameObject.SetActive(true);
        isActive = true;
    }

    public void CheckStatues()
    {
        gameObject.SetActive(false);

        itemManager.isActive = false;
    }
}