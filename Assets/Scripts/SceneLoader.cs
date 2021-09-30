using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private PlayerInteract playerInteract;

    private void Start()
    {
        playerInteract = GetComponent<PlayerInteract>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerInteract.score == 0)
        {
            SceneController.LoadScene("Level1");
        }

        if (playerInteract.score >= 3)
        {
            SceneController.LoadScene("Kitchen2");
        }

        if (playerInteract.score >= 3)
        {
            SceneController.LoadScene("Kitchen3");
        }

        if (playerInteract.score >= 1)
        {
            SceneController.LoadScene("Level2");
        }

        if (playerInteract.score >= 1)
        {
            SceneController.LoadScene("Level3");
        }

        if (playerInteract.score >= 1)
        {
            SceneController.LoadScene("EndScene");
        }
    }
}    
