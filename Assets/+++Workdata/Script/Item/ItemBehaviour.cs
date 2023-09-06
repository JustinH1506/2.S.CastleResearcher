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

    /// <summary>
    /// playerControllerMap is new PlayerControllerMap.
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
    /// Calling UpdateItem from inevntoryManager, set gameObject to false, play getItemSound.
    /// </summary>
    /// <param name="context"></param>
    public void Interacted(InputAction.CallbackContext context)
    {
        if (player == null) return;

        if(inevntoryManager.UpdateItem(itemSO))
        gameObject.SetActive(false);
        AudioManager.instance.PlayOneShot(FMODEvents.instance.getItemSound, transform.position);
    }
}