using UnityEngine;
using UnityEngine.InputSystem;
using FMOD.Studio;

public class PlayerMovement : MonoBehaviour
{
    #region Components

    [SerializeField] Transform groundPoint;

    Rigidbody2D rb;

    SpriteRenderer sr;

    Animator anim;

    PlayerControllerMap playerControllerMap;
    private InputAction moveAction;

    public LayerMask WhatIsGround;

    #endregion
    #region Variables
    public float moveSpeed;

    private float inputX;

    public bool isWalking;

    private EventInstance footSteps;

    #region Arrays


    #endregion

    [SerializeField] bool isGrounded;
    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        footSteps = AudioManager.instance.CreateInstance(FMODEvents.instance.footSteps);
    }

    private void Awake()
    {
        playerControllerMap = new PlayerControllerMap();
    }

    private void OnEnable()
    {
        playerControllerMap.Enable();

        playerControllerMap.Player.Move.performed += Move;
        playerControllerMap.Player.Move.canceled += Move;
    }

    private void OnDisable()
    {
        playerControllerMap.Disable();

        playerControllerMap.Player.Move.performed -= Move;
        playerControllerMap.Player.Move.canceled -= Move;
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

        UpdateSound();
    }
    #region CallbackContext Methods
    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }
    #endregion

    private void UpdateSound()
    {
        if (rb.velocity.x != 0)
        {
            PLAYBACK_STATE playBackState;
            footSteps.getPlaybackState(out playBackState);
            if (playBackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                footSteps.start();
            }
        }
        else
        {
            footSteps.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }
}