using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
   private PlayerCollision _enemyCollision;
   private EnemyHealth _enemyHealth;
   
   
   private void Start()
   {
      _enemyCollision = GetComponent<PlayerCollision>();
      _enemyHealth = GetComponent<EnemyHealth>();
   }
}
