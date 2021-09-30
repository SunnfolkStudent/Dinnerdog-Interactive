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
    public bool isDashing = false;
    public bool canDash = true;
    [Header("Dash Cooldown")]
    public float cooldown = 0.7f;
    
    //Save position
    [HideInInspector] public Vector2 savePosition;
    
    
    private void Start()
    {
        _Input = GetComponent<PlayerInput>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        
        InvokeRepeating(nameof(PosTime), 3f, 3f);
    }

    private void Update()
    {
        if (_Input.dash && !isDashing && canDash)
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
        StartCoroutine(DashCooldown());
    }

    private IEnumerator DashCooldown()
    {
        print("Dash cooldown initiated");
        canDash = false;
        yield return new WaitForSeconds(cooldown);
        print("dash cooldown is over");
        canDash = true;
    }
    private void PosTime()
    {
        if (isDashing) return;
        savePosition = transform.position;
    }
}