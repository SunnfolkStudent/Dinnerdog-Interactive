using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Managers;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerInteract : MonoBehaviour
{

    public static float score = 0f;
    public static bool cookiedeath = false;
    [Space(5)] 
    public string MainMenu;
    public string WinSceen;
    public bool canInteract;
    public GameObject breakfast;
    public GameObject lunch;

    private PlayerInput _input;
    private HealthManager _health;
    
    private PlayerAudio _audio;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _health = GetComponent<HealthManager>();
        breakfast.SetActive(false);
        lunch.SetActive(false);
        _audio = GetComponent<PlayerAudio>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            
        }
        if (other.CompareTag("DogTreat"))
        {
            HealthManager.lives++;
            Destroy(other.gameObject);
            _audio.heal();
            
        }

        if (other.CompareTag("Cookie"))
        {
            HealthManager.SetLives(0);
            Destroy(other.gameObject);
            cookiedeath = true;
        }

        if (other.CompareTag("Food"))
        {
            score++;
            Destroy(other.gameObject);
            _audio.food();
        }
        
        /*
        if (other.CompareTag("Exit"))
        {
            if (score <= 3)
            {
                print("Press F to Exit");
                canInteract = true;
            }
        }
        */
        
        if (other.CompareTag("PortalKitchen1"))
        {
            SceneController.LoadScene("Level1");
            score = 0;
        }
        if (other.CompareTag("PortalLevel1"))
        {
            if (score >= 3)
            {
                SceneController.LoadScene("Kitchen2");
                score = 0;
            }
        }
        if (other.CompareTag("PortalKitchen2"))
        {
            if (score >= 1)
            {
                SceneController.LoadScene("Level2");
                score = 0;
            }
            
        }
        if (other.CompareTag("PortalLevel2"))
        {
            if (score >= 3)
            {
                SceneController.LoadScene("Kitchen3");
                score = 0;
            }
        }

        if (other.CompareTag("PortalKitchen3"))
        {
            if (score >= 1)
            {
                SceneController.LoadScene("Level3");
                score = 0;
            }
        }

        if (other.CompareTag("PortalLevel3"))
        {
            if (score >= 3)
            {
                SceneController.LoadScene("EndScene");
                score = 0;
            }
        }
    
        if (other.CompareTag("TableCollider1") && score < 1)
        {
            score++;
            breakfast.SetActive(true);
        }

        if (other.CompareTag("TableCollider2") && score < 1)
        {
            score++;
            lunch.SetActive(true);
        }

    }

   /* private void Update()
    {
        print("Current score: " +score);
    }
    */
}