using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class signSystem : MonoBehaviour
{
    public GameObject text;

    private void Start()
    {
        text.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Sign"))
        {
            text.SetActive(true);
        }
        else
        {
            text.SetActive(false);
        }
    }
}
