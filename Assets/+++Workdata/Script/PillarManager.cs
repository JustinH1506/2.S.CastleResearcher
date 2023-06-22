using UnityEngine;

public class PillarManager : MonoBehaviour
{
    [SerializeField] PillarBehavior[] pillarBehaviors;
    [SerializeField] GameObject first_door;
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

    private void ResetPillars()
    {
        for (int i = 0; i < pillarBehaviors.Length; i++)
        {
            pillarBehaviors[i].pressed = false;
        }
    }

    private void Success()
    {
        first_door.SetActive(false);
    }
}