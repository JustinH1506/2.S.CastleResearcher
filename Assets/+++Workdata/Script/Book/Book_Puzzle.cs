using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Book_Puzzle : MonoBehaviour
{
    [SerializeField] PlayerControllerMap playerControllerMap;

    [SerializeField] PlayerInteract playerInteract;

    [SerializeField] ItemManager itemManager;

    [SerializeField] GameObject bookShelf_Cutscene;

    [SerializeField] GameObject inventarBook;

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
    /// return if player is null, gameobject gets deacitvated and bookShelfCutscene gets activated.
    /// </summary>
    /// <param name="context"></param>
    public void Interacted(InputAction.CallbackContext context)
    {
        if (player == null) return;

        if(context.performed && player != null && itemManager.isActive == true)
        {
            gameObject.SetActive(false);

            bookShelf_Cutscene.SetActive(true);

            inventarBook.SetActive(false);
        }
    }
}