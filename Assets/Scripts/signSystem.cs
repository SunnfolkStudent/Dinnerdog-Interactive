using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
// using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class signSystem : MonoBehaviour
{
    public GameObject text;
    public GameObject title;
    public GameObject image;

    public GameObject light1;
    public GameObject light2;

    public GameObject propercookietext;

   

    private void Start()
    {
        text.SetActive(false);
        title.SetActive(true);
        image.SetActive(true);
        light1.SetActive(false);
        light2.SetActive(false);
        propercookietext.SetActive(false);
    }

    private void Update()
    {
        HUD();
        cookietext();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") /*&& PlayerInteract.score <= 0*/)
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerInteract.score <= 0)
        {
            text.SetActive(false);
        }
    }
    private void HUD()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            title.SetActive(false);
            image.SetActive(false);
            light1.SetActive(true);
            light2.SetActive(true);
        }
    }

    private void cookietext()
    {
        if (PlayerInteract.cookiedeath)
        {
            propercookietext.SetActive(true);
        }
        else
        {
            propercookietext.SetActive(false);
        }
    }
}