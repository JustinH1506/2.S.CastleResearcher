using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Last_Door : MonoBehaviour
{
    [SerializeField] PlayerControllerMap playerControllerMap;

    public GameObject player;

    public GameObject lastDoorCutscene;

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

        playerControllerMap.Player.Interact.performed += Interact;
    }

    /// <summary>
    /// Disable playerControllerMap, performen Interacted Method.
    /// </summary>
    private void OnDisable()
    {
        playerControllerMap.Disable();

        playerControllerMap.Player.Interact.performed -= Interact;
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

    public void Interact(InputAction.CallbackContext context)
    {
        if(context.performed && player != null)
        {
            lastDoorCutscene.SetActive(true);
        }
    }
}
