using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InevntoryManager : MonoBehaviour
{
    [SerializeField] Image itemImage;

    public ItemSO itemSO { get; private set; }

    /// <summary>
    /// Return if ClearItem method gets called, return true if AddItem gets called. 
    /// </summary>
    /// <param name="newItemSO"></param>
    /// <returns></returns>
    public bool UpdateItem(ItemSO newItemSO)
    {
        if (ClearItem(newItemSO)) return false;

        if(AddItem(newItemSO)) return true;
        return false;
    }


    /// <summary>
    /// If newItemSo is not null return, make itemSo null, itemImage to null, make opacity to 0, return true.
    /// </summary>
    /// <param name="newItemSO"></param>
    /// <returns></returns>
    bool ClearItem(ItemSO newItemSO)
    {
        if (newItemSO != null) return false;
        itemSO = null;

        itemImage.sprite = null;
        Color opacityOff = new(1f, 1f, 1f, 0);
        itemImage.color = opacityOff;
        return true;
    }

    /// <summary>
    /// If itemSO is not null return false, itemSO is newItemSo, Opacity is 255, itemImage sprite gets to itemSO´s itemSprite.
    /// </summary>
    /// <param name="newItemSO"></param>
    /// <returns></returns>
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