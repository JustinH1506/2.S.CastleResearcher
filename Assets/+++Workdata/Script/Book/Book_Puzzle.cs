using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Book_Puzzle : MonoBehaviour
{
    [SerializeField] PlayerInteract playerInteract;

    [SerializeField] ItemManager itemManager;

    [SerializeField] GameObject bookShelf_Cutscene;

    [SerializeField] GameObject door;

    public GameObject player;

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

        if(context.performed && player != null && itemManager.isActive == true)
        {
            gameObject.SetActive(false);

            bookShelf_Cutscene.SetActive(true);
        }
    }
}