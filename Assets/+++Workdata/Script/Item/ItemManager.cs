using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] ItemBehaviour itemBehaviour;
    [SerializeField] GameObject[] itemObjects_InGame;
    [SerializeField] GameObject[] itemObjects_Inventar;

    public bool inRange;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    public void CheckItem()
    {
        if(itemBehaviour.pressed == true)
        {
            itemObjects_InGame[itemBehaviour.itemID].SetActive(false);
            itemObjects_Inventar[itemBehaviour.inventarID].SetActive(true);
        }
    }
}
