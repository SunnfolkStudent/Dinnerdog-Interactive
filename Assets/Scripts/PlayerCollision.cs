using System;
using Managers;

#if UNITY_EDITOR
using UnityEditor.UIElements;
#endif
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerMovement _movement;
    
    private HealthManager healthManager;
  

    private void Start()
    {
        healthManager = GetComponent<HealthManager>();
        _movement = GetComponent<PlayerMovement>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player Pit") && !_movement.isDashing)
        {
            healthManager.ReduceLives();
            transform.position = _movement.savePosition;
        }
        
        if (other.CompareTag("Enemy"))
        {
            healthManager.ReduceLives();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player Pit") && !_movement.isDashing)
        {
            healthManager.ReduceLives();
            transform.position = _movement.savePosition;
        }
    }
}