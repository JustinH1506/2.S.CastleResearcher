using Cinemachine;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    #region Scripts
    [SerializeField] PlayerDoor playerDoor;

    [SerializeField] PlayerControllerMap playerControllerMap;
    #endregion

    #region GameObjects

    [SerializeField] GameObject tutorialButtons;

    [SerializeField] GameObject wButton;

    #endregion

    #region Variables
    public int interact_count = 0;

    public int inventar_count;

    public bool isUsable;
    #endregion

    /// <summary>
    /// We make our playerControllerMap our new PlayerControllerMap
    /// </summary>
    public void Awake()
    {
        playerControllerMap = new PlayerControllerMap();
    }

    /// <summary>
    /// We enable the playerControllerMap and perform the Door interact Method.
    /// </summary>
    private void OnEnable()
    {
        playerControllerMap.Enable();

        playerControllerMap.Player.Door_Interact.performed += Door_Interact;
    }

    /// <summary>
    /// We disable the playerControllerMap and 
    /// </summary>
    private void OnDisable()
    {
        playerControllerMap.Disable();

        playerControllerMap.Player.Door_Interact.performed -= Door_Interact;
    }

    #region Updates
    #endregion

    #region OntriggerEnter&OnTriggerExit
    /// <summary>
    /// Load scene 1, wButton gets active, isUsable gets true, interactCount gets to 6.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Scene_Switch"))
        {
            SceneManager.LoadScene(1);
        }

        if (collision.CompareTag("Door_1"))
        {
            wButton.SetActive(true);
            isUsable = true;
        }
        else if (collision.CompareTag("Door_2"))
        {
            interact_count = 6;
        }
    }

    /// <summary>
    /// wButton gets false, isUsable true, interactCount 0.
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Door_1"))
        {
            wButton.SetActive(false);
            isUsable = false;
        }
        else if (collision.CompareTag("Door_2"))
        {
            interact_count = 0;
        }
    }
    #endregion

    #region CallbackContext Methods 

    /// <summary>
    /// Calling CheckWaitTime Method from PlayerDoor.
    /// </summary>
    /// <param name="context"></param>
    public void Door_Interact(InputAction.CallbackContext context)
    {
        if (context.performed && isUsable == true)
        {
            playerDoor.CheckWaitTime();
        }
    }
    #endregion

    /// <summary>
    /// tutorial buttons get active, waits for 2 seconds, tutorial buttons get false.
    /// </summary>
    /// <returns></returns>
    IEnumerator Wait()
    {
        tutorialButtons.SetActive(true);

        yield return new WaitForSeconds(2f);

        tutorialButtons.SetActive(false);
    }

    #region Own Mehtods
    /// <summary>
    /// Start Wait Coroutine.
    /// </summary>
    public void Tutorial()
    {
        StartCoroutine("Wait");
    }

    #endregion
}