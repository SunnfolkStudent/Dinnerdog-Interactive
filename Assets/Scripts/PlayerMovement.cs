using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private float dashForce = 5f;
    
    [SerializeField] private LayerMask whatIsPit;
    
    private PlayerInput _Input;
    
    private Rigidbody2D _Rigidbody2D;
    
    private void Start()
    {
        _Input = GetComponent<PlayerInput>();
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        _Rigidbody2D.velocity = 
            new Vector2(_Input.moveVector.x * moveSpeed, _Input.moveVector.y * moveSpeed);
    }
    
    private void Dash()
    {
        if (_Input.downDash)
        {
            _Rigidbody2D.AddForce(Vector2.down * dashForce, ForceMode2D.Impulse);
        }
    }
}



