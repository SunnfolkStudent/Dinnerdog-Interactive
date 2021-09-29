using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private SceneController sceneController;
    private PlayerInteract playerInteract;

    private void Start()
    {
        sceneController = GetComponent<SceneController>();
        playerInteract = GetComponent<PlayerInteract>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
        }
    }
}
