using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    // public AudioClip Jump;


    private AudioSource _AudioSource;
    private PlayerInput _Input;
    private PlayerMovement _playerMovement;
    private PlayerCollision _collision;
    
    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _Input = GetComponent<PlayerInput>();
        _playerMovement = GetComponent<PlayerMovement>();
        _collision = GetComponent<PlayerCollision>();
    }
    void Update()
    {
        
    }
    
    /* private void Audioname()
    {
        _AudioSource.pitch = Random.Range(0.5f, 1.5f);
        _AudioSource.PlayOneShot(walking);
    } */
}