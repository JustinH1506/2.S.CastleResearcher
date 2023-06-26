using UnityEngine;
using UnityEngine.InputSystem;

public class PillarBehavior : MonoBehaviour
{
    [SerializeField] int pillarID;
    [SerializeField] PillarManager pillarManager;
    [SerializeField] GameObject player;
    public bool pressed;

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
    }
    #endregion
}
