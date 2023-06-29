using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] ItemManager itemManager;
    [SerializeField] GameObject player;

    public  int itemID;
    public int inventarID;

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

        if(context.performed && itemManager.inRange == true)
        {
            pressed = true;
        }
    }
}
