using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemBehaviour : MonoBehaviour
{
    PlayerControllerMap playerControllerMap;
    [SerializeField] ItemSO itemSO;
    [SerializeField] InevntoryManager inevntoryManager;
    GameObject player;

    private void Awake()
    {
        playerControllerMap = new PlayerControllerMap();

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

        if(inevntoryManager.UpdateItem(itemSO))
        gameObject.SetActive(false);
    }
}