using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Book_Puzzle : MonoBehaviour
{
    public GameObject book;

    public GameObject inventar_Book;

    public GameObject bookshelf;

    public bool isBook;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isBook = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isBook = false;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
            if(context.performed && isBook)
        {
            book.SetActive(false);

            inventar_Book.SetActive(true);
        }
    }
}
