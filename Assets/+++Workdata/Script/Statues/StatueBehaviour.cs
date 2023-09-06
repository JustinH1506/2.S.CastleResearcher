using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StatueBehaviour : MonoBehaviour
{
    [SerializeField] StatueManager statueManager;
    [SerializeField] Sprite[] statueStates;
    PlayerControllerMap playerControllerMap;
    [SerializeField] ItemSO itemSO;
    [SerializeField] InevntoryManager inevntoryManager;
    [SerializeField] Animator anim;
    SpriteRenderer sr;
    GameObject player;
    

    [SerializeField] int succesID;

    /// <summary>
    /// We make our playerControllerMap our new PlayerControllerMap
    /// </summary>
    private void Awake()
    {
        playerControllerMap = new PlayerControllerMap();

        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// We enable the playerControllerMap and perform the Door interact Method.
    /// </summary>
    private void OnEnable()
    {
        playerControllerMap.Enable();

        playerControllerMap.Player.Interact.performed += Interacted;
    }

    /// <summary>
    /// We disable the playerControllerMap and 
    /// </summary>
    private void OnDisable()
    {
        playerControllerMap.Disable();

        playerControllerMap.Player.Interact.performed -= Interacted;
    }

    /// <summary>
    /// return if Player is not in the collider, make player GameObject to collision gameobject.
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        player = collision.gameObject;
    }

    /// <summary>
    /// return if Player is not in the collider, if we exit the player is null.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        player = null;
    }

    /// <summary>
    /// Calls methods depending on the item that we had and the item that the statues have. 
    /// </summary>
    public void Interacted(InputAction.CallbackContext context)
    {
        if (player == null) return;

        if (itemSO == null && inevntoryManager.itemSO == null) return;

        if (SwitchItem()) return;

        if (GiveItem()) return;

        if (AddItem()) return;

        UpdateSprite();
    }

    /// <summary>
    /// Gives us the item depending on itemSO.
    /// </summary>
    /// <returns></returns>
    private bool GiveItem()
    {
        if (itemSO == null && inevntoryManager.itemSO != null) return false;

        inevntoryManager.UpdateItem(itemSO);
        itemSO = null;

        UpdateSprite();

        return true;
    }


    /// <summary>
    /// Updates the sprite depending on the statue and itemSO.
    /// </summary>
    private void UpdateSprite()
    {
        if (itemSO != null)
            sr.sprite = statueStates[itemSO.itemID];
        else sr.sprite = statueStates[0];
    }

    /// <summary>
    /// Gives a statue an the item that the player had.
    /// </summary>
    private bool AddItem()
    {
        if (inevntoryManager.itemSO == null) return false;

        itemSO = inevntoryManager.itemSO;

        inevntoryManager.UpdateItem(null);

        UpdateSprite();
        CheckID();

        return true;
    }

    /// <summary>
    /// switches the item from the statue and the player.
    /// </summary>
    /// <returns></returns>
    bool SwitchItem()
    {
        if (inevntoryManager.itemSO == null) return false;

        if (itemSO == null) return false;

        ItemSO itemSOSave = inevntoryManager.itemSO;

        inevntoryManager.UpdateItem(null);
        inevntoryManager.UpdateItem(itemSO);

        itemSO = itemSOSave;

        UpdateSprite();
        CheckID();

        return true;
    }

    /// <summary>
    /// Checks if the ID are the same and calls 
    /// </summary>
    void CheckID()
    {
        bool succes = succesID == itemSO.itemID ? true : false;

        statueManager.CheckSucces(succesID, succes);
    }
}