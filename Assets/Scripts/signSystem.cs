using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class signSystem : MonoBehaviour
{
    public GameObject text;
    public GameObject title;
    public GameObject image;

    private void Start()
    {
        text.SetActive(false);
        title.SetActive(true);
        image.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && PlayerInteract.score <= 0)
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        {
            text.SetActive(false);
        }
    }

    private void hud()
    {
        if (Input.anyKey)
        {
            title.SetActive(false);
            image.SetActive(false);
        }
    }
    
    
}