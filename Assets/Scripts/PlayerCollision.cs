using System;
using Managers;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public string whatIsPit;
    public string whoIsEnemy;
    private PlayerInput _input;
    private PlayerMovement _movement;

    private SceneController sceneControl;
    private HealthManager healthManager;
    private PlayerAudio _audio;

    private void Start()
    {
        sceneControl = GetComponent<SceneController>();
        healthManager = GetComponent<HealthManager>();
        _input = GetComponent<PlayerInput>();
        _movement = GetComponent<PlayerMovement>();
        _audio = GetComponent<PlayerAudio>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Pit") && !_movement.isDashing)
        { 
            print("Die");
            healthManager.ReduceLives();
            transform.position = _movement.savePosition;
        }
        
        if (other.CompareTag("Enemy"))
        {
            print("hit");
            healthManager.ReduceLives();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player Pit") && !_movement.isDashing)
        { 
            print("Die");
            healthManager.ReduceLives();
            transform.position = _movement.savePosition;
        }
    }
}