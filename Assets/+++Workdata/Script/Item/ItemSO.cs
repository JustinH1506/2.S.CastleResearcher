using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Items", order = 0)]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemSprite;
    public int itemID;
}