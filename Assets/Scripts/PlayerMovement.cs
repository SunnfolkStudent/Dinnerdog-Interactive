using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    //Components
    private PlayerInput _Input;
    private Rigidbody2D _Rigidbody2D;
    
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    
    [Header("Pits")]
    [SerializeField] private LayerMask whatIsPit;
    
    [Header("Dash")]
    [SerializeField] private float dashForce = 15f;
    public float dashTime = 0.3f;  //WaitForSeconds in IEnumerator
    public float dashCooldown = 2;
    private bool isDashing = false;
    
    
    private void Start()
    {
        _Input = GetComponent<PlayerInput>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_Input.dash && !isDashing)
        {
            StartCoroutine(Dash());
        }
        else if (!isDashing)
        {
            _Rigidbody2D.velocity = new Vector2(_Input.moveVector.x * moveSpeed, _Input.moveVector.y * moveSpeed);
        }
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        print("dash");
        _Rigidbody2D.velocity = _Input.moveVector * dashForce;
        yield return new WaitForSeconds(0.3f);
        _Rigidbody2D.velocity = Vector2.zero;
        isDashing = false;
    }
}