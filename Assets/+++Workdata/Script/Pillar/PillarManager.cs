using System.Collections;
using UnityEngine;

public class PillarManager : MonoBehaviour
{
    [SerializeField] PillarBehavior[] pillarBehaviors;
    [SerializeField] GameObject first_door;
    [SerializeField] GameObject winCutscene;
    [SerializeField] Animator[] anim, lampAnim;
    public bool isNotTriggerd;

    /// <summary>
    /// If the Array in pillarBeahviour thats pressed is not equal to i Starts ResetPillar method and returns false,
    /// 
    /// IF the pillarID is equal to the length of the pillarBehaviour array Succes method gets called and returns true.
    /// </summary>
    /// <param name="pillarID"></param>
    /// <returns></returns>
    public bool CheckContext(int pillarID)
    {
        for (int i = 0; i < pillarID - 1; i++)
        {
            if (!pillarBehaviors[i].pressed)
            {
                ResetPillars();
                return false;
            }
        }
        if (pillarID == pillarBehaviors.Length) Success();

        return true;
    }

    /// <summary>
    /// pillarBehaviours pressed set to false, lever and lamp Bool is set and set to false.
    /// </summary>
    private void ResetPillars()
    {
        for (int i = 0; i < pillarBehaviors.Length; i++)
        {
            pillarBehaviors[i].pressed = false;

            anim[i].SetBool("isNotTriggered", isNotTriggerd);

            lampAnim[i].SetBool("isNotTriggered", isNotTriggerd);

            isNotTriggerd = true;
        }
    }

    /// <summary>
    /// firstDoor gets deactivated, winCutscene gets activated. 
    /// </summary>
    private void Success()
    {
        first_door.SetActive(false);
        winCutscene.SetActive(true);
    }
}
