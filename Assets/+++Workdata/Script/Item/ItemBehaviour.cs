using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] Inventar_Items inventarItems;
    [SerializeField] ItemManager itemManager;
    public GameObject player;

    public bool pressed;

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

        if (context.performed && player != null && itemManager.isActive == false)
        {
            gameObject.SetActive(false);

            inventarItems.CheckInventar();
            itemManager.isActive = true;
        }
    }
}