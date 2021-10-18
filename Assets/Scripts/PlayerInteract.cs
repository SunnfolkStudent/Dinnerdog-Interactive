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
    public GameObject breakfast;
    public GameObject lunch;

    private PlayerAudio _audio;

    private void Start()
    {
        breakfast.SetActive(false);
        lunch.SetActive(false);
        _audio = GetComponent<PlayerAudio>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DogTreat"))
        {
            HealthManager.lives++;
            _audio.heal();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Cookie"))
        {
            HealthManager.SetLives(0);
            cookiedeath = true;
            Destroy(other.gameObject);
            
        }

        if (other.CompareTag("Food"))
        {
            score++;
            _audio.food();
            Destroy(other.gameObject);
            
        }

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
}