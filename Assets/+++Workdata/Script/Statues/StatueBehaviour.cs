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


    private void Awake()
    {
        playerControllerMap = new PlayerControllerMap();

        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControllerMap.Enable();

        playerControllerMap.Player.Interact.performed += Interacted;
    }

    private void OnDisable()
    {
        playerControllerMap.Disable();

        playerControllerMap.Player.Interact.performed -= Interacted;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        player = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        player = null;
    }

    public void Interacted(InputAction.CallbackContext context)
    {
        if (player == null) return;

        if (itemSO == null && inevntoryManager.itemSO == null) return;

        if (SwitchItem()) return;

        if (GiveItem()) return;

        if (AddItem()) return;

        UpdateSprite();
    }

    private bool GiveItem()
    {
        if (itemSO == null && inevntoryManager.itemSO != null) return false;

        inevntoryManager.UpdateItem(itemSO);
        itemSO = null;

        UpdateSprite();

        return true;
    }

    private void UpdateSprite()
    {
        if (itemSO != null)
            sr.sprite = statueStates[itemSO.itemID];
        else sr.sprite = statueStates[0];
    }

    private bool AddItem()
    {
        if (inevntoryManager.itemSO == null) return false;

        itemSO = inevntoryManager.itemSO;

        inevntoryManager.UpdateItem(null);

        UpdateSprite();
        CheckID();

        return true;
    }

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

    void CheckID()
    {
        bool succes = succesID == itemSO.itemID ? true : false;

        statueManager.CheckSucces(succesID, succes);
    }
}