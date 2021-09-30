using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerInteract : MonoBehaviour
{

    public static float score = 0f;
    [Space(5)] 
    public string MainMenu;
    public string WinSceen;
    public bool canInteract;
    public GameObject breakfast;
    public GameObject lunch;

    private PlayerInput _input;
    private HealthManager _health;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        _health = GetComponent<HealthManager>();
        breakfast.SetActive(false);
        lunch.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        {
            
        }
        if (other.CompareTag("DogTreat"))
        {
            HealthManager.lives++;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Cookie"))
        {
            HealthManager.lives--;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Food"))
        {
            score++;
            Destroy(other.gameObject);
        }
        
        if (other.CompareTag("Exit"))
        {
            if (score <= 3)
            {
                print("Press F to Exit");
                canInteract = true;
            }
        }
        
        if (other.CompareTag("PortalKitchen1"))
        {
            SceneController.LoadScene("Level1");
        }
        if (other.CompareTag("PortalLevel1"))
        {
            if (score >= 3)
            {
                SceneController.LoadScene("Kitchen2");
            }
            else
            {
                print("Granny needs more food");
            }
        }
        if (other.CompareTag("PortalKitchen2"))
        {
            if (score >= 1)
            {
                SceneController.LoadScene("Level2");
            }
            else
            {
                print("Granny needs her food");
            }
        }
        if (other.CompareTag("PortalLevel2"))
        {
            if (score >= 3)
            {
                print("you can now go to score 3");
                SceneController.LoadScene("Kitchen3");
            }
            else
            {
                print("Granny needs more food");
            }
        }

        if (other.CompareTag("PortalKitchen3"))
        {
            if (score >= 3)
            {
                SceneController.LoadScene("Level3");
            }
            else
            {
                print("Granny needs her food");
            }
        }

        if (other.CompareTag("PortalLevel3"))
        {
            if (score >= 3)
            {
                SceneController.LoadScene("EndScene");
            }
            else
            {
                print("Granny needs her food");
            }
        }
    
        if (other.CompareTag("TableCollider1") && score < 1)
        {
            score++;
            breakfast.SetActive(true);
            print("food worked so you should be happy");
        }

        if (other.CompareTag("TableCollider2") && score < 1)
        {
            print("lunch has been placed");
            score++;
            lunch.SetActive(true);
        }

    }

    private void Update()
    {
        print("Current score: " +score);
    }
}