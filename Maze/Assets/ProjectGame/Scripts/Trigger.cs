using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    private GameObject levelEndPanel;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelEndPanel.SetActive(true);
        }
    }
}
