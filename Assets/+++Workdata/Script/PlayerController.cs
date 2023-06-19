using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;
using TMPro;
using Ink.Runtime;
using UnityEngine.Rendering.Universal;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public int lever_count = 0;

    public int interact_count = 0;

    public int book_count = 0;

    #region GameObjetcs

    public GameObject first_door;

    public GameObject interact_button_text_for_room;

    public GameObject interact_button_text_castle_room;

    public GameObject book;

    public GameObject next_Scene_Door;

    public GameObject inventar_Book;

    public GameObject bookshelf_cutscene;

    [SerializeField] CinemachineVirtualCamera vcam01;

    [SerializeField] CinemachineVirtualCamera vcam02;


    #endregion

    public Transform groundPoint;

    public LayerMask WhatIsGround;

    public float moveSpeed, jumpForce;

    private float inputX;

    private bool isGrounded;
    #endregion

    #region Updates

    private void Start()
    {
     
    }

    /// <summary>
    /// In this Update mehtod the Player gets a square which checks if it is on the ground or not. Looks if the lever count equals to 
    /// 4 and if it is deactivates it in the Hierarchy
    /// </summary>
    void Update()
    {
        if (lever_count == 4)
        {
            first_door.SetActive(false);
        }
    }

    /// <summary>
    /// In this FixedUpdate mehtod the Player gets a square which checks if it is on the ground or not. Tells the rigidbody´s velocity
    /// to calculate the value inputX + the move speed to get movement for the Player
    /// </summary>
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, WhatIsGround);

        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        if(rb.velocity.x < 0f)
        {
            sr.flipX = true;
        }
        else if(rb.velocity.x > 0f)
        {
            sr.flipX = false;
        }
    }
    #endregion

    #region Ontrigger_OnCollision
    /// <summary>
    /// Looks for the Player entering the Triggerzone of Gameobjects with certian Tags. The Bridge_Breaker Tag makes the bridge
    /// dissapear, Scene_Switch loads the scene with the index 1, and Camera_Switch gives the second camera a higher priority. Lever_1
    /// to Lever_4 activate the Text to press Q above the Player and makes teh interact_counter higher for the interact button. 
    /// </summary>
    /// <param name="collision"></param>

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scene_Switch"))
        {
            SceneManager.LoadScene(1);
        }

        if (collision.gameObject.CompareTag("CameraSwitch"))
        {
            vcam01.m_Priority = 16;
        }
        else if (collision.gameObject.CompareTag("Camera_Switch_Library"))
        {
            vcam02.m_Priority = 20;
        }
        else if (collision.gameObject.CompareTag("Camera_Switch_back_to_Pillar"))
        {
            vcam02.m_Priority = 14;
        }
        else if (collision.gameObject.CompareTag("Camera_Switch_before_room"))
        {
            vcam01.m_Priority = 10;
        }

        if (collision.gameObject.CompareTag("Lever_1"))
        {
            interact_button_text_castle_room.SetActive(true);
            interact_count = 1;
        }

        if (collision.gameObject.CompareTag("Lever_2"))
        {
            interact_button_text_castle_room.SetActive(true);
            interact_count = 2;
        }

        if (collision.gameObject.CompareTag("Lever_3"))
        {
            interact_button_text_castle_room.SetActive(true);
            interact_count = 3;
        }

        if (collision.gameObject.CompareTag("Lever_4"))
        {
            interact_button_text_castle_room.SetActive(true);
            interact_count = 4;
        }

        if (collision.gameObject.CompareTag("Book"))
        {
            book_count = 1;
        }

        if (book.activeInHierarchy == false && collision.gameObject.CompareTag("Bookshelf"))
        {
            book_count = 2;
        }

        if (collision.CompareTag("Door_1"))
        {
            interact_count = 5;
        }
    }

    /// <summary>
    /// when leaving the Triggerzones from Lever_1 to Lever_4 the Text gets deactivated and the interact_count gets set to 0.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lever_1"))
        {
            interact_button_text_castle_room.SetActive(false);
            interact_count = 0;
        }

        if (collision.gameObject.CompareTag("Lever_2"))
        {
            interact_button_text_castle_room.SetActive(false);
            interact_count = 0;
        }

        if (collision.gameObject.CompareTag("Lever_3"))
        {
            interact_button_text_castle_room.SetActive(false);
            interact_count = 0;
        }

        if (collision.gameObject.CompareTag("Lever_4"))
        {
            interact_button_text_castle_room.SetActive(false);
            interact_count = 0;
        }
    }
    #endregion

    #region CallbackContext Methods
    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("Working");
        }
    }   

    public void Interact(InputAction.CallbackContext context)
    {
        if(context.performed && lever_count == 0 && interact_count == 1)
        {
            lever_count++;
        }
        else if (context.performed && lever_count == 1 && interact_count == 2) 
        {
            lever_count++;
        }
        else if (context.performed && lever_count == 2 && interact_count == 3)
        {
            lever_count++;
        }
        else if (context.performed && lever_count == 3 && interact_count == 4)
        {
            lever_count++;
        }
        else if (context.performed && lever_count > 0 && interact_count >= 1 && interact_count < 5)
        {
            lever_count = 0;
        }
        else if (context.performed && lever_count > 1 && interact_count >=1 && interact_count < 5)
        {
            lever_count = 0;
        }
        else if (context.performed && lever_count > 2 && interact_count >=1 && interact_count < 5)
        {
            lever_count = 0;
        }

        if(context.performed && book_count == 1)
        {
            book.SetActive(false);
            inventar_Book.SetActive(true);

        }
        else if(context.performed && book_count == 2)
        {
            bookshelf_cutscene.SetActive(true);
            inventar_Book.SetActive(false) ;
        }
    }

    public void Door_Interact(InputAction.CallbackContext context)
    {
        if (context.performed && interact_count == 5)
        {
            SceneManager.LoadScene(3);
        }
    }
    #endregion

    #region
    public void Door()
    {
        next_Scene_Door.GetComponent<BoxCollider2D>().enabled = true;
    }
    #endregion
}