using UnityEngine;
using UnityEngine.InputSystem;

public class PillarBehavior : MonoBehaviour
{
    [SerializeField] int pillarID;
    [SerializeField] PillarManager pillarManager;
    [SerializeField] GameObject player;
    [SerializeField] Animator anim;
    public bool pressed;
    public bool isNotTriggered;

    public void Update()
    {
        if(pressed)
        {
            anim.SetTrigger("Triggered");
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
        anim.SetBool("isNotTriggered",isNotTriggered);
        isNotTriggered = false;
    }
    #endregion
}
