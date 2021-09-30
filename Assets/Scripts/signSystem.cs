using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class signSystem : MonoBehaviour
{
    public GameObject text;

    private PlayerInteract _interact;

    private void Start()
    {
        text.SetActive(false);
        _interact = GetComponent<PlayerInteract>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            text.SetActive(false);
        }
    }
}