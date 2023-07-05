using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Book : MonoBehaviour
{
    [SerializeField] PlayerControllerMap playerControllerMap;

    [SerializeField] GameObject inventarBook;

    [SerializeField] GameObject eButton;

    [SerializeField] ItemManager itemManager;

    public GameObject player;

    /// <summary>
    /// We get the playerControllerMap and make it equal to a new PlayerControllerMap.
    /// </summary>
    private void Awake()
    {
        playerControllerMap = new PlayerControllerMap();
    }

    /// <summary>
    /// Enable playerControllerMap, performen Interacted Method.
    /// </summary>
    private void OnEnable()
    {
        playerControllerMap.Enable();

        playerControllerMap.Player.Interact.performed += Interacted;
    }

    /// <summary>
    /// Disable playerControllerMap, performen Interacted Method.
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

        if (player != null) eButton.SetActive(true);
    }

    /// <summary>
    /// return if Player is not in the collider, if we exit the player is null.
    /// </summary>
    /// <param name="collision"></param>

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        player = null;

        if (player == null) eButton.SetActive(false);
    }

    public void Interacted(InputAction.CallbackContext context)
    {
        if (player == null) return;

        if (context.performed && player != null)
        {
            gameObject.SetActive(false);

            inventarBook.SetActive(true);

            itemManager.isActive = true;
        }
    }
}
