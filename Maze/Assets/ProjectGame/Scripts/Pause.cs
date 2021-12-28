using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [HideInInspector]
    public bool isPaused;
    [SerializeField]
    public KeyCode pauseButton;
    [SerializeField]
    public GameObject pausePanel;
    [SerializeField]
    private GameObject player;
    private PlayerLook playerLook;
    // Start is called before the first frame update
    void Start()
    {
        playerLook = player.GetComponent<PlayerLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            isPaused = !isPaused;
        }
        if (isPaused)
        {
            pausePanel.SetActive(true);
            playerLook.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
        else
        {
            pausePanel.SetActive(false);
            playerLook.enabled = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
        }
    }
}
