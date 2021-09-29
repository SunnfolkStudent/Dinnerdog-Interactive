using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerInteract : MonoBehaviour
{

    public float score = 0f;
    [Space(5)] 
    public string MainMenu;
    public string WinSceen;
    public bool canInteract;

    private PlayerInput _input;
    private HealthManager _health;
    
    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _health = GetComponent<HealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Food"))
        {
            score++;
            HealthManager.lives++;
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("Exit"))
        {
            if (score <= 3)
            {
                canInteract = true;
                print("Press F to Exit");
            }
        }
    }
}