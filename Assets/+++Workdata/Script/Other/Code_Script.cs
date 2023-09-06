using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Code_Script : MonoBehaviour
{
    PlayerControllerMap playerControllerMap;

    [SerializeField] PlayerMovement playerMovement;

    public Animator anim;

    public GameObject buttons;

    public TextMeshProUGUI number_1;

    public TextMeshProUGUI number_2;

    public TextMeshProUGUI number_3;

    private int code_1;

    private int code_2;

    private int code_3;

    private bool player;

    private bool isActive;

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

        playerControllerMap.Player.Interact.performed += Interact;
    }

    /// <summary>
    /// We disable the playerControllerMap and 
    /// </summary>
    private void OnDisable()
    {
        playerControllerMap.Disable();

        playerControllerMap.Player.Interact.performed -= Interact;
    }

    /// <summary>
    /// makes player true if it is the object with Player tag.
    /// </summary>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = true;
        }
    }

    /// <summary>
    /// makes player false if it is not an object with Player tag.
    /// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = false;
        }
    }

    /// <summary>
    /// Puts the code1 to code 3 to 1 and changes the text 1 to 3 to 1 depending if ther are any in the code before.
    /// </summary>
    public void Code_1()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);

        if (code_1 == 0)
        {
            code_1 = 1;

            number_1.text = "1";
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 1;

            number_2.text = "1";
        }
        else
        {
            code_3 = 1;

            number_3.text = "1";
        }
    }

    /// <summary>
    /// Puts the code1 to code 3 to 2 and changes the text 1 to 3 to 2 depending if ther are any in the code before.
    /// </summary>
    public void Code_2()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);
        if (code_1 == 0)
        {
            code_1 = 2;
            number_1.text = "2";
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 2;
            number_2.text = "2";
        }
        else
        {
            code_3 = 2;
            number_3.text = "2";
        }
    }

    /// <summary>
    /// Puts the code1 to code 3 to 3 and changes the text 1 to 3 to 3 depending if ther are any in the code before.
    /// </summary>
    public void Code_3()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);
        if (code_1 == 0)
        {
            code_1 = 3;
            number_1.text = "3";
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 3;
            number_2.text = "3";
        }
        else
        {
            code_3 = 3;
            number_3.text = "3";
        }
    }

    /// <summary>
    /// Puts the code1 to code 3 to 4 and changes the text 1 to text 3 to 4 depending if ther are any in the code before.
    /// </summary>
    public void Code_4()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);
        if (code_1 == 0)
        {
            code_1 = 4;
            number_1.text = "4";
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 4;
            number_2.text = "4";
        }
        else
        {
            code_3 = 4;
            number_3.text = "4";
        }
    }

    /// <summary>
    /// Puts the code1 to code 3 to 5 and changes the text 1 to 3 to 5 depending if ther are any in the code before.
    /// </summary>
    public void Code_5()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);
        if (code_1 == 0)
        {
            code_1 = 5;
            number_1.text = "5";
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 5;
            number_2.text = "5";
        }
        else
        {
            code_3 = 5;
            number_3.text = "5";
        }
    }

    /// <summary>
    /// Puts the code 1 to code 3 to 6 and changes the text 1 to 3 to 6 depending if ther are any in the code before.
    /// </summary>
    public void Code_6()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);
        if (code_1 == 0)
        {
            code_1 = 6;
            number_1.text = "6";
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 6;
            number_2.text = "6";
        }
        else
        {
            code_3 = 6;
            number_3.text = "6";
        }
    }

    /// <summary>
    /// Puts the code1 to code 3 to 7 and changes the text 1 to 3 to 7 depending if ther are any in the code before.
    /// </summary>
    public void Code_7()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);
        if (code_1 == 0)
        {
            code_1 = 7;
            number_1.text = "7";
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 7;
            number_2.text = "7";
        }
        else
        {
            code_3 = 7;
            number_3.text = "7";
        }
    }

    /// <summary>
    /// Puts the code1 to code 3 to 8 and changes the text 1 to 3 to 8 depending if ther are any in the code before.
    /// </summary>
    public void Code_8()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);
        if (code_1 == 0)
        {
            code_1 = 8;
            number_1.text = "8";
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 8;
            number_2.text = "8";
        }
        else
        {
            code_3 = 8;
            number_3.text = "8";
        }
    }

    /// <summary>
    /// Puts the code1 to code 3 to 9 and changes the text 1 to 3 to 9 depending if ther are any in the code before.
    /// </summary>
    public void Code_9()
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.clickButton, transform.position);
        if (code_1 == 0)
        {
            code_1 = 9;
            number_1.text = "9";
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 9;
            number_2.text = "9";
        }
        else
        {
            code_3 = 9;
            number_3.text = "9";
        }
    }

    /// <summary>
    /// CHanges the code and text back to 0 if it was not the right code.
    /// </summary>
    public void Update()
    {
        if (code_1 == 4 && code_2 == 1 && code_3 == 3)
        {
            anim.SetTrigger("Triggered");

            playerMovement.moveSpeed = 7;

            buttons.SetActive(false);
        }
        else if (code_1 != 4 && code_1 != 0 && code_2 != 1 && code_2 != 0 && code_3 != 3 && code_3 != 0)
        {
            code_1 = 0;

            code_2 = 0;

            code_3 = 0;

             number_1.text = "0";

        number_2.text = "0";

        number_3.text = "0";
        }
        else if (code_1 == 4 && code_1 != 0 && code_2 != 1 && code_2 != 0 && code_3 != 3 && code_3 != 0)
        {
            code_1 = 0;

            code_2 = 0;

            code_3 = 0;

            number_1.text = "0";

            number_2.text = "0";

            number_3.text = "0";
        }
        else if (code_1 == 4 && code_1 != 0  && code_2 == 1 && code_2 != 0  && code_3 != 3 && code_3 != 0)
        {
            code_1 = 0;

            code_2 = 0;

            code_3 = 0;

            number_1.text = "0";

            number_2.text = "0";

            number_3.text = "0";
        }
        else if (code_1 != 4 && code_1 != 0 && code_2 != 1 && code_2 != 0 && code_3 == 3 && code_3 != 0)
        {
            code_1 = 0;

            code_2 = 0;

            code_3 = 0;

            number_1.text = "0";

            number_2.text = "0";

            number_3.text = "0";
        }
    }

    /// <summary>
    /// Activates the code Panel and deactivates it.
    /// </summary>
    /// <param name="context"></param>
    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && player == true && isActive == false)
        {
            buttons.SetActive(true);

            playerMovement.moveSpeed = 0;

            isActive = true;
        }
        else if(context.performed && player == true && isActive == true)
        {
            buttons.SetActive(false);

            isActive = false;

            playerMovement.moveSpeed = 7;
        }
    }
}