using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float dashForce = 100f;
    
    [SerializeField] private LayerMask whatIsPit;
    
    private PlayerInput _Input;
    
    private Rigidbody2D _Rigidbody2D;
    
    private void Start()
    {
        _Input = GetComponent<PlayerInput>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Dash();
    }

    private void FixedUpdate()
    {
        _Rigidbody2D.velocity = 
            new Vector2(_Input.moveVector.x * moveSpeed, _Input.moveVector.y * moveSpeed);
    }
    
    private void Dash()
    {
        if (_Input.dash)
        {
            print("dash");
            _Rigidbody2D.AddForce(_Input.moveVector * dashForce, ForceMode2D.Impulse);
        }
    }
}



