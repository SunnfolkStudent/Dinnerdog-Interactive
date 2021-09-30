using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudio : MonoBehaviour
{
    // public AudioClip Jump;
    private AudioSource _AudioSource;
    private PlayerInput _Input;
    private PlayerMovement _playerMovement;
    private PlayerCollision _collision;
    private PlayerAnimations _animations;

    public AudioClip BIGDOG;
    public AudioClip GrannyTrans;

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
        if (!_AudioSource.isPlaying)
        {
            _AudioSource.pitch = Random.Range(0.8f, 1.2f);
            _AudioSource.PlayOneShot(BIGDOG);   
        }
    }

    private void grandma()
    {
        _AudioSource.PlayOneShot(GrannyTrans);
    }
}