using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticlas : MonoBehaviour
{
    public static ParticleSystem DustParticals;
    public GameObject _dustParticals;
    
    
    private void Start()
    {
        DustParticals = _dustParticals.GetComponent<ParticleSystem>();
    }

    public static void CreatDuse()
    {
        DustParticals.Play();
    }
}
