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

    private void Awake()
    {
        playerControllerMap = new PlayerControllerMap();
    }

    private void OnEnable()
    {
        playerControllerMap.Enable();

        playerControllerMap.Player.Interact.performed += Interact;
    }

    private void OnDisable()
    {
        playerControllerMap.Disable();

        playerControllerMap.Player.Interact.performed -= Interact;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = false;
        }
    }
    public void Code_1()
    {
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

    public void Code_2()
    {
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

    public void Code_3()
    {
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

    public void Code_4()
    {
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

    public void Code_5()
    {
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

    public void Code_6()
    {
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

    public void Code_7()
    {
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

    public void Code_8()
    {
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

    public void Code_9()
    {
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

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && player == true)
        {
            buttons.SetActive(true);

            playerMovement.moveSpeed = 0;
        }
    }
}