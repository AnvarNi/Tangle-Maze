using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject levelEndPanel;
    [HideInInspector]
    public bool isPaused;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject player;
    private PlayerLook playerLook;

    void Start()
    {
        playerLook = player.GetComponent<PlayerLook>();
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (other.tag == "Player")
            {
                isPaused = !isPaused;
                levelEndPanel.SetActive(true);
                playerLook.enabled = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else
            {
                levelEndPanel.SetActive(false);
                playerLook.enabled = true;
                Time.timeScale = 1;
            }
        }
    }
}
