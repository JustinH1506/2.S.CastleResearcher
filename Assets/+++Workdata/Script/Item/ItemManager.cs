using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] ItemBehaviour itemBehaviour;
    [SerializeField] GameObject[] itemObjects_InGame;
    [SerializeField] GameObject[] itemObjects_Inventar;

    public bool CheckItems(int itemID)
    {
      for (int i = 0; i <= itemID; i++)
        {
            if (itemBehaviour.pressed)
            {
                itemObjects_InGame[i].SetActive(false);

                itemObjects_Inventar[i].SetActive(true);

                return true;
            }
        }
      return false;
    }
}
