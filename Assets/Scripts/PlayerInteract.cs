using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Space(5)] 
    public string MainMenu;
    public string WinSceen;
    public bool canInteract;

    private PlayerInput _input;
    
    private void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        
    }
}
