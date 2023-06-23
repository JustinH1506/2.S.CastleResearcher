using UnityEngine;

public class PillarManager : MonoBehaviour
{
    [SerializeField] PillarBehavior[] pillarBehaviors;
    [SerializeField] GameObject first_door;
    [SerializeField] Animator anim;

    public void Start()
    {
        
    }
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
        anim.SetTrigger("triggerd");
        return true;
    }

    private void ResetPillars()
    {
        for (int i = 0; i < pillarBehaviors.Length; i++)
        {
            pillarBehaviors[i].pressed = false;
            anim.SetTrigger("triggerd");
        }
    }

    private void Success()
    {
        first_door.SetActive(false);
    }
}
