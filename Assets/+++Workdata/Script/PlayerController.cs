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

    public GameObject proteinpowder_Outside;

    public GameObject handcuffs_Outside;

    public GameObject ribbons_Outside;

    public GameObject proteinpowder_Inventar;

    public GameObject handcuffs_Inventar;

    public GameObject ribbon_Inventar;

    public GameObject protein_Statue;

    public GameObject protein_Empty_Statue;

    public GameObject handcuff_Statue_Fake_1;

    public GameObject ribbon_Statue_Fake_1;

    public GameObject handcuff_Statue;

    public GameObject handcuff_Empty_Statue;

    public GameObject protein_Statue_Fake_1;

    public GameObject ribbon_Statue_Fake_2;

    public GameObject ribbon_Statue;

    public GameObject ribbon_empty_Statue;

    public GameObject protein_Statue_Fake_2;

    public GameObject handcuff_Statue_Fake_2;
 

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
        else if (collision.CompareTag("Lever_2"))
        {
            interact_button_text_castle_room.SetActive(true);
            interact_count = 2;
        }
        else if (collision.CompareTag("Lever_3"))
        {
            interact_button_text_castle_room.SetActive(true);
            interact_count = 3;
        }
        else if (collision.CompareTag("Lever_4"))
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
        else if (collision.CompareTag("Proteinpowder"))
        {
            interact_count = 7;
        }
        else if (collision.CompareTag("Handcuffs"))
        {
            interact_count = 8;
        }
        else if (collision.CompareTag("Ribbon"))
        {
            interact_count = 9;
        }
        else if (collision.CompareTag("Proteinpowder_Statue"))
        {
            interact_count = 10;
        }
        else if (collision.CompareTag("Handcuff_Statue"))
        {
            interact_count = 11;
        }
        else if (collision.CompareTag("Ribbon_Statue"))
        {
            interact_count = 12;
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

        if (collision.CompareTag("Door_1"))
        {
            interact_count = 0;
        }
        else if (collision.CompareTag("Door_2"))
        {
            interact_count = 0;
        }

        if (collision.CompareTag("Book"))
        {
            book_count = 0;
        }

        if (collision.CompareTag("Proteinpowder"))
        {
            interact_count = 0;
        }
        else if (collision.CompareTag("Handcuffs"))
        {
            interact_count = 0;
        }
        else if (collision.CompareTag("Ribbon"))
        {
            interact_count = 0;
        }
        else if (collision.CompareTag("Proteinpowder_Statue"))
        {
            interact_count = 0;
        }
        else if (collision.CompareTag("Handcuff_Statue"))
        {
            interact_count = 0;
        }
        else if (collision.CompareTag("Ribbon_Statue"))
        {
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

         if(context.performed && interact_count == 7 && inventar_count == 0)
        {
            proteinpowder_Outside.SetActive(false);
            proteinpowder_Inventar.SetActive(true);
            inventar_count = 1;
        }
         else if(context.performed && interact_count == 8 && inventar_count == 0)
        {
            handcuffs_Outside.SetActive(false);
            handcuffs_Inventar.SetActive(true);
            inventar_count = 1;
        }
         else if(context.performed && interact_count == 9 && inventar_count == 0)
        {
            ribbons_Outside.SetActive(false);
            ribbon_Inventar.SetActive(true);
            inventar_count = 1;
        }

         if(proteinpowder_Inventar.activeInHierarchy && context.performed && interact_count == 10)
        {
            protein_Empty_Statue.SetActive(false);
            protein_Statue.SetActive(true);

            proteinpowder_Inventar.SetActive(false);

            inventar_count = 0;
        }
         else if(handcuffs_Inventar.activeInHierarchy && context.performed && interact_count == 10)
        {
            protein_Empty_Statue.SetActive(false);
            handcuff_Statue_Fake_1.SetActive(true);

            handcuffs_Inventar.SetActive(false);

            inventar_count = 0;
        }
        else if (ribbon_Inventar.activeInHierarchy && context.performed && interact_count == 10)
        {
            protein_Empty_Statue.SetActive(false);
            ribbon_Statue_Fake_1.SetActive(true);

            ribbon_Inventar.SetActive(false);

            inventar_count = 0;
        }

        if (handcuffs_Inventar.activeInHierarchy && context.performed && interact_count == 11)
        {
            handcuff_Empty_Statue.SetActive(false);
            handcuff_Statue.SetActive(true);

            handcuffs_Inventar.SetActive(false);

            inventar_count = 0;
        }
        else if(proteinpowder_Inventar.activeInHierarchy && context.performed && interact_count == 11)
        {

            handcuff_Empty_Statue.SetActive(false);
            protein_Statue_Fake_1.SetActive(true);

            proteinpowder_Inventar.SetActive(false);

            inventar_count = 0;
        }
        else if(ribbon_Inventar.activeInHierarchy && context.performed && interact_count == 11)
        {

            handcuff_Empty_Statue.SetActive(false);
            ribbon_Statue_Fake_2.SetActive(true);

            ribbon_Inventar.SetActive(false);

            inventar_count = 0;
        }

        if(ribbon_Inventar.activeInHierarchy && context.performed && interact_count == 12)
        {
            ribbon_empty_Statue.SetActive(false);
            ribbon_Statue.SetActive(true);

            ribbon_Inventar.SetActive(false);

            inventar_count = 0;
        }
        else if(proteinpowder_Inventar.activeInHierarchy && context.performed && interact_count == 12)
        {
            ribbon_empty_Statue.SetActive(false);
            protein_Statue_Fake_2.SetActive(true);

            proteinpowder_Inventar.SetActive(false);

            inventar_count = 0;
        }
        else if (handcuffs_Inventar.activeInHierarchy && context.performed && interact_count == 12)
        {
            ribbon_empty_Statue.SetActive(false);
            handcuff_Statue_Fake_2.SetActive(true);

            handcuffs_Inventar.SetActive(false);

            inventar_count = 0;
        }

        if(context.performed && interact_count == 10 && inventar_count == 0 && handcuff_Statue_Fake_1.activeInHierarchy)
        {
            protein_Empty_Statue.SetActive(true);
            handcuff_Statue_Fake_1.SetActive(false);

            handcuffs_Inventar.SetActive(true);

            interact_count = 1;
        }
        else if(context.performed && interact_count == 10 && inventar_count == 0 && ribbon_Statue_Fake_1.activeInHierarchy)
        {
            protein_Empty_Statue.SetActive(true);
            ribbon_Statue_Fake_1.SetActive(false);

            ribbon_Inventar.SetActive(true);

            interact_count = 1;
        }

        if(context.performed && interact_count == 11 && inventar_count == 0 && protein_Statue_Fake_1.activeInHierarchy)
        {
            handcuff_Empty_Statue.SetActive(true);
            protein_Statue_Fake_1.SetActive(false);

            proteinpowder_Inventar.SetActive(true);

            interact_count = 1; 
        }
        else if (context.performed && interact_count == 11 && inventar_count == 0 && ribbon_Statue_Fake_2.activeInHierarchy)
        {
            handcuff_Empty_Statue.SetActive(true);
            ribbon_Statue_Fake_2.SetActive(false);

            ribbon_Inventar.SetActive(true);

            interact_count = 1;
        }

        if(context.performed && interact_count == 12 && inventar_count == 0 && protein_Statue_Fake_2.activeInHierarchy)
        {
            ribbon_empty_Statue.SetActive(true);
            protein_Statue_Fake_2.SetActive(false);

            proteinpowder_Inventar.SetActive(true);

            inventar_count = 1;
        }
        else if (context.performed && interact_count == 12 && inventar_count == 0 && handcuff_Statue_Fake_2.activeInHierarchy)
        {
            ribbon_empty_Statue.SetActive(true);
            handcuff_Statue_Fake_2.SetActive(false);

            handcuffs_Inventar.SetActive(true);

            inventar_count = 1;
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