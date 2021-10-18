using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudio : MonoBehaviour
{
    private AudioSource _AudioSource;
    private signSystem _sign;

    [Header("Player")]
    public AudioClip BIGDOG; 
    public AudioClip Damage;
    public AudioClip Heal;
    public AudioClip Food;
    
    [Header("Grandma")]
    public AudioClip GrannyTrans;
    public AudioClip Ding;
   

    private void Start()
    {
        _AudioSource = GetComponent<AudioSource>();
        _sign = GetComponent<signSystem>();
    }
    private void BarkAudio() //Event in player bark animation
    {
        if (!_AudioSource.isPlaying)
        {
            _AudioSource.pitch = Random.Range(0.8f, 1.2f);
            _AudioSource.PlayOneShot(BIGDOG);   
        }
    }
    private void grandma()  //Event in grandma animation
    {
        _AudioSource.PlayOneShot(GrannyTrans);
    }

    private void ding()  //Event in grandma animation
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