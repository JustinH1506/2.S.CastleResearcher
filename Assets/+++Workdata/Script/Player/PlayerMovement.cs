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

    [SerializeField] bool isGrounded;
    #endregion

    /// <summary>
    /// Gets RigidBody2D, SpriteRenderer and Animator, sets footsepSounds.
    /// </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        footSteps = AudioManager.instance.CreateInstance(FMODEvents.instance.footSteps);
    }

    /// <summary>
    /// We make our playerControllerMap our new PlayerControllerMap
    /// </summary>
    private void Awake()
    {
        playerControllerMap = new PlayerControllerMap();
    }

    /// <summary>
    /// We enable the playerControllerMap and perform the Door interact Method.
    /// </summary>
    private void OnEnable()
    {
        playerControllerMap.Enable();

        playerControllerMap.Player.Move.performed += Move;
        playerControllerMap.Player.Move.canceled += Move;
    }

    /// <summary>
    /// We disable the playerControllerMap and 
    /// </summary>
    private void OnDisable()
    {
        playerControllerMap.Disable();

        playerControllerMap.Player.Move.performed -= Move;
        playerControllerMap.Player.Move.canceled -= Move;
    }

    /// <summary>
    /// Makes it possible tu walk, set the walk animation on true and off and calls UodateSound method.
    /// </summary>
    private void FixedUpdate()
    {

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

    /// <summary>
    /// Gets the inputX value for walking.
    /// </summary>
    /// <param name="context"></param>
    public void Move(InputAction.CallbackContext context)
    {
        inputX = context.ReadValue<Vector2>().x;
    }
    #endregion

    /// <summary>
    /// Makes the footsteps get played while walking, if not walking footspes stop with fadeOut from the sound.
    /// </summary>
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