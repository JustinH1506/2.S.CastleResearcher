using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    #region Components

    public Transform groundPoint;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public Animator anim;

    public LayerMask WhatIsGround;

    #endregion

    #region Variables
    public int lever_count = 0;

    public int interact_count = 0;

    public int book_count = 0;

    public int inventar_count;

    public float moveSpeed, jumpForce;

    private float inputX;

    public bool isWalking;

    private bool isGrounded;
    #endregion

    #region GameObjetcs

    public GameObject first_door;

    public GameObject interact_button_text_for_room;

    public GameObject interact_button_text_castle_room;

    public GameObject book;

    public GameObject next_Scene_Door;

    public GameObject inventar_Book;

    public GameObject bookshelf_cutscene;

    public GameObject empty_Bookshelf;

    #endregion 

    #region Serialized field
    [SerializeField] CinemachineVirtualCamera vcam01;

    [SerializeField] CinemachineVirtualCamera vcam02;
    #endregion

    #region Updates
    private void Start()
    {
     
    }

    void Update()
    {
        if (lever_count == 4)
        {
            first_door.SetActive(false);
        }

        anim.SetBool("isWalking", isWalking);
    }

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

        if(rb.velocity.x != 0)
        {
            isWalking = true;
        }
        else if(rb.velocity.x == 0)
        {
            isWalking = false;
        }
    }
    #endregion

    #region OntriggerEnter&OnTriggerExit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scene_Switch"))
        {
            SceneManager.LoadScene(1);
        }

        if (collision.CompareTag("CameraSwitch"))
        {
            vcam01.m_Priority = 16;
        }
        else if (collision.gameObject.CompareTag("Camera_Switch_Library"))
        {
            vcam02.m_Priority = 20;
        }
        else if (collision.CompareTag("Camera_Switch_back_to_Pillar"))
        {
            vcam02.m_Priority = 14;
        }
        else if (collision.CompareTag("Camera_Switch_before_room"))
        {
            vcam01.m_Priority = 10;
        }

        if (collision.CompareTag("Lever_1"))
        {
            interact_button_text_castle_room.SetActive(true);
            interact_count = 1;
        }

        if (collision.CompareTag("Lever_2"))
        {
            interact_button_text_castle_room.SetActive(true);
            interact_count = 2;
        }

        if (collision.CompareTag("Lever_3"))
        {
            interact_button_text_castle_room.SetActive(true);
            interact_count = 3;
        }

        if (collision.CompareTag("Lever_4"))
        {
            interact_button_text_castle_room.SetActive(true);
            interact_count = 4;
        }

        if (collision.CompareTag("Book"))
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
        else if (collision.CompareTag("Door_2"))
        {
            interact_count = 6;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lever_1"))
        {
            interact_button_text_castle_room.SetActive(false);
            interact_count = 0;
        }
        else if (collision.gameObject.CompareTag("Lever_2"))
        {
            interact_button_text_castle_room.SetActive(false);
            interact_count = 0;
        }
        else if (collision.gameObject.CompareTag("Lever_3"))
        {
            interact_button_text_castle_room.SetActive(false);
            interact_count = 0;
        }
        else if (collision.gameObject.CompareTag("Lever_4"))
        {
            interact_button_text_castle_room.SetActive(false);
            interact_count = 0;
        }

        if (collision.CompareTag("Book"))
        {
            book_count = 0;
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

        if(context.performed && book_count == 1 && inventar_count == 0)
        {
            book.SetActive(false);
            inventar_Book.SetActive(true);
            inventar_count = 1;
        }

         if(context.performed && book_count == 2)
        {
            StartCoroutine("Wait");
        }
    }

    public void Door_Interact(InputAction.CallbackContext context)
    {
        if (context.performed && interact_count == 5)
        {
            SceneManager.LoadScene(3);
        }
        else if (context.performed && interact_count == 6)
        {
            SceneManager.LoadScene(2);
        }
    }
    #endregion

    #region IEnumerator
    public IEnumerator Wait()
    {
        bookshelf_cutscene.SetActive(true);
        inventar_Book.SetActive(false);
        empty_Bookshelf.SetActive(false);
        inventar_count = 0;

        yield return new WaitForSeconds(3f);

        next_Scene_Door.GetComponent<BoxCollider2D>().enabled = true;
    }
    #endregion
}