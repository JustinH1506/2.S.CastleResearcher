using UnityEngine;
using UnityEngine.InputSystem;

public class PillarBehavior : MonoBehaviour
{
    [SerializeField] int pillarID;

    [SerializeField] PlayerControllerMap playerControllerMap;
    [SerializeField] PillarManager pillarManager;
    [SerializeField] GameObject player;
    [SerializeField] Animator anim;
    [SerializeField] Animator lampAnim;
    public bool pressed;
    public bool isNotTriggered;

    private void Awake()
    {
        playerControllerMap = new PlayerControllerMap();
    }

    private void OnEnable()
    {
        playerControllerMap.Enable();

        playerControllerMap.Player.Interact.performed += Interacted;
        playerControllerMap.Player.Interact.canceled += Interacted;
    }

    private void OnDisable()
    {
        playerControllerMap.Disable();

        playerControllerMap.Player.Interact.performed -= Interacted;
        playerControllerMap.Player.Interact.canceled -= Interacted;
    }

    public void Update()
    {
        if(pressed)
        {
            anim.SetTrigger("Triggered");

            lampAnim.SetTrigger("Triggered");
        }
    }
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
