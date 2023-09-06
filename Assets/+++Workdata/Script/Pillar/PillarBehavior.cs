using UnityEngine;
using UnityEngine.InputSystem;

public class PillarBehavior : MonoBehaviour
{
    [SerializeField] int pillarID;

    [SerializeField] PlayerControllerMap playerControllerMap;
    [SerializeField] PillarManager pillarManager;
    [SerializeField] GameObject player;
    [SerializeField] GameObject eButton;
    [SerializeField] Animator anim;
    [SerializeField] Animator lampAnim;
    public bool pressed;
    public bool isNotTriggered;


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
    /// Set trigger for button animation and lamp animation.
    /// </summary>
    public void Update()
    {
        if(pressed)
        {
            anim.SetTrigger("Triggered");

            lampAnim.SetTrigger("Triggered");
        }
    }

    /// <summary>
    /// return if Player is not in the collider, make player GameObject to collision gameobject, makes e button true.
    /// </summary>
    /// <param name="collision"></param>
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        player = collision.gameObject;
        eButton.SetActive(true);
    }

    /// <summary>
    /// return if Player is not in the collider, if we exit the player is null, makes eButton false.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        player = null;
        eButton.SetActive(false);
    }

    /// <summary>
    /// Sets the le´ver sound when pressed, sets the isNotTriggered bool for lever and lamp, sets isNotTriggered to false.
    /// </summary>
    /// <param name="context"></param>
    #region InteractInput
    public void Interacted(InputAction.CallbackContext context)
    {
        if (player == null) return;
        pressed = pillarManager.CheckContext(pillarID);

        if(context.performed) AudioManager.instance.PlayOneShot(FMODEvents.instance.lever, transform.position);

        anim.SetBool("isNotTriggered",isNotTriggered);

        lampAnim.SetBool("isNotTriggered", isNotTriggered);

        isNotTriggered = false;
    }
    #endregion
}
