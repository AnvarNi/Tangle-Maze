using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    public void ResumeGame(GameObject obj)
    {
        obj.GetComponent<Pause>().isPaused = false;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
