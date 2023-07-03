using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDoor: MonoBehaviour
{
    public GameObject player_Door_Cutscene;

    public GameObject player;

    public GameObject player_2;

    /// <summary>
    /// Start the Wait Corotine.
    /// </summary>
    public void CheckWaitTime()
    {
        StartCoroutine("Wait");
    }

    /// <summary>
    /// Seting player on false, player2 true, playerDoor_Cutscene true, wait for 2 seconds and load scene 3.
    /// </summary>
    /// <returns></returns>
    public IEnumerator Wait()
    {
        player.SetActive(false);

        player_2.SetActive(true);

        player_Door_Cutscene.SetActive(true);

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(3);
    }
}
