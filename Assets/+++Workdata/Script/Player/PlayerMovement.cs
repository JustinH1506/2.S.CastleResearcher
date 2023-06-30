using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Components

    [SerializeField] Transform groundPoint;

    Rigidbody2D rb;

    SpriteRenderer sr;

    Animator anim;

    public LayerMask WhatIsGround;

    public LayerMask WhatIsGround2;

    public LayerMask WhatIsGround3;

    #endregion
    #region Variables
    public float moveSpeed, jumpForce;

    private float inputX;

    public bool isWalking;

    #region Arrays


    #endregion

    [SerializeField] bool isGrounded;
    #endregion
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundPoint.position, .2f, WhatIsGround);

        rb.velocity = new Vector2(inputX * moveSpeed, rb.velocity.y);

        if (rb.velocity.x < 0f)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x > 0f)
        {
            sr.flipX = false;
        }

        if (rb.velocity.x != 0)
        {
            isWalking = true;
            anim.SetBool("isWalking", isWalking);
        }
        else if (rb.velocity.x == 0)
        {
            isWalking = false;
            anim.SetBool("isWalking", isWalking);
        }
    }
    #region CallbackContext Methods
    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }
    #endregion
}