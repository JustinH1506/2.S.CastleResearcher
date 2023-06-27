using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] ItemBehaviour itemBehaviour;
    [SerializeField] GameObject[] itemObjects_InGame;
    [SerializeField] GameObject[] itemObjects_Inventar;

    public bool CheckItems(int itemID)
    {
        for (int i = 0; i < itemID; i++)
        {
            if (i != itemID)
            {
                return false;
            }
        }
        gameObject.SetActive(false);
        itemObjects_Inventar[itemID].SetActive(true);
        return true;
    }
}
