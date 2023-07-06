using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueManager : MonoBehaviour
{
    [SerializeField] bool[] statueSucces;
    //[SerializeField] Animator[] anim;
    [SerializeField] GameObject blockade;
    [SerializeField] GameObject winLight;

    public void CheckSucces(int ID, bool condition)
    {
        statueSucces[ID] = condition;
        for (int i = 1; i < statueSucces.Length; i++)
        {
            if (!statueSucces[i]) return;
        }
        blockade.SetActive(false);
        winLight.SetActive(true);
    }
}
