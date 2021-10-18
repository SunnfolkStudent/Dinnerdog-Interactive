using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("AttackCollider"))
      {
         GetComponent<EnemyHealth>().EnemyTakeDamage(1);
      }
   }
}
