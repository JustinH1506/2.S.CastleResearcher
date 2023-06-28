using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Code_Script : MonoBehaviour
{
    public Animator anim;

    public GameObject buttons;

    public int code_1;

    public int code_2;

    public int code_3;

    public bool player;

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
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 1;
        }
        else
        {
            code_3 = 1;
        }
    }

    public void Code_2()
    {
        if (code_1 == 0)
        {
            code_1 = 2;
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 2;
        }
        else
        {
            code_3 = 2;
        }
    }

    public void Code_3()
    {
        if (code_1 == 0)
        {
            code_1 = 3;
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 3;
        }
        else
        {
            code_3 = 3;
        }
    }

    public void Code_4()
    {
        if (code_1 == 0)
        {
            code_1 = 4;
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 4;
        }
        else
        {
            code_3 = 4;
        }
    }

    public void Code_5()
    {
        if (code_1 == 0)
        {
            code_1 = 5;
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 5;
        }
        else
        {
            code_3 = 5;
        }
    }

    public void Code_6()
    {
        if (code_1 == 0)
        {
            code_1 = 6;
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 6;
        }
        else
        {
            code_3 = 6;
        }
    }

    public void Code_7()
    {
        if (code_1 == 0)
        {
            code_1 = 7;
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 7;
        }
        else
        {
            code_3 = 7;
        }
    }

    public void Code_8()
    {
        if (code_1 == 0)
        {
            code_1 = 8;
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 8;
        }
        else
        {
            code_3 = 8;
        }
    }

    public void Code_9()
    {
        if (code_1 == 0)
        {
            code_1 = 9;
        }
        else if (code_1 != 0 && code_2 == 0)
        {
            code_2 = 9;
        }
        else
        {
            code_3 = 9;
        }
    }

    public void Update()
    {
        if (code_1 == 4 && code_2 == 1 && code_3 == 3)
        {
            anim.SetTrigger("Triggered");

            buttons.SetActive(false);
        }
        else if (code_1 != 4 && code_1 != 0 && code_2 != 1 && code_2 != 0 && code_3 != 3 && code_3 != 0)
        {
            code_1 = 0;

            code_2 = 0;

            code_3 = 0;
        }
        else if (code_1 == 4 && code_1 != 0 && code_2 != 1 && code_2 != 0 && code_3 != 3 && code_3 != 0)
        {
            code_1 = 0;

            code_2 = 0;

            code_3 = 0;
        }
        else if (code_1 == 4 && code_1 != 0  && code_2 == 1 && code_2 != 0  && code_3 != 3 && code_3 != 0)
        {
            code_1 = 0;

            code_2 = 0;

            code_3 = 0;
        }
        else if (code_1 != 4 && code_1 != 0 && code_2 != 1 && code_2 != 0 && code_3 == 3 && code_3 != 0)
        {
            code_1 = 0;

            code_2 = 0;

            code_3 = 0;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (context.performed && player == true)
        {
            buttons.SetActive(true);
        }
    }
}