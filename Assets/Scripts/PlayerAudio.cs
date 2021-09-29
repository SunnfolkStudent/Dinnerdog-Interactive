using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;


public class PlayerAudio : MonoBehaviour
{
    // public AudioClip Jump;
    
    private AudioSource _AudioSource;
    private PlayerInput _Input;
    private PlayerMovement _playerMovement;
    private PlayerCollision _collision;
    private PlayerAnimations _animations;

    public AudioClip BIGDOG;
    
    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _Input = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        _collision = GetComponent<PlayerCollision>();
        _animations = GetComponent<PlayerAnimations>();
    }
    private void BarkAudio()
    {
        _AudioSource.PlayOneShot(BIGDOG);
    }
}