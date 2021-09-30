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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && _interact.score == 0)
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