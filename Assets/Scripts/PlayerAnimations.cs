using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerAnimation : MonoBehaviour
{
    #region Variables
    
    private Animator _animator;
    private PlayerInput _playerInput;
    private PlayerMovement _movement;
    private PlayerCollision _collision;

    private Rigidbody2D _rigidbody2D;
    
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _movement = GetComponent<PlayerMovement>();
        _collision = GetComponent<PlayerCollision>();


    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInput.moveVector.x != 0)
        {
            transform.localScale = new Vector2(_playerInput.moveVector.x, 1f);
        }

        if (_playerInput.moveVector.y > 0)
        {
            _animator.Play("PlayerMoveUp");
        }
        else if (_playerInput.moveVector.y < 0)
        {
            _animator.Play("PlayerMoveDown");
        }
        else if (_playerInput.moveVector.x != 0)
        {
            _animator.Play("PlayerWalk");
        }
        else
        {
            _animator.Play("PlayerIdle");
        }
    }
}