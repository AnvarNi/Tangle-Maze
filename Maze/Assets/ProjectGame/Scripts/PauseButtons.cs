using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtons : MonoBehaviour
{
    public void ResumeGame(GameObject obj)
    {
        obj.GetComponent<Pause>().isPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
