using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InevntoryManager : MonoBehaviour
{
    [SerializeField] Image itemImage;

    public ItemSO itemSO { get; private set; }

    public bool UpdateItem(ItemSO newItemSO)
    {
        if (ClearItem(newItemSO)) return false;

        if(AddItem(newItemSO)) return true;
        return false;
    }

    bool ClearItem(ItemSO newItemSO)
    {
        if (newItemSO != null) return false;
        itemSO = null;

        itemImage.sprite = null;
        Color opacityOff = new(1f, 1f, 1f, 0);
        itemImage.color = opacityOff;
        return true;
    }

    bool AddItem(ItemSO newItemSO)
    {
        if (itemSO != null) return false;

        itemSO = newItemSO;

        Color opacityON = new(1f, 1f, 1f, 255f);
        itemImage.color = opacityON;

        itemImage.sprite = itemSO.itemSprite;
        return true;
    }
}