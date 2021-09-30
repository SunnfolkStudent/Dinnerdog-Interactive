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
    private signSystem _sign;

    public AudioClip BIGDOG;
    public AudioClip GrannyTrans;
    public AudioClip Ding;
    public AudioClip Damage;
    public AudioClip Heal;
    public AudioClip Food;

    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _Input = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        _collision = GetComponent<PlayerCollision>();
        _animations = GetComponent<PlayerAnimations>();
        _sign = GetComponent<signSystem>();
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

    private void ding()
    {
        _AudioSource.PlayOneShot(Ding);
        _sign.text.SetActive(true);
    }

    public void damage()
    {
        _AudioSource.PlayOneShot(Damage);
    }

    public void heal()
    {
        _AudioSource.PlayOneShot(Heal);
    }

    public void food()
    {
        _AudioSource.PlayOneShot(Food);
    }
}