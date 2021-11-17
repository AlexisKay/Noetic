using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int dmg = 25;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>() != null) {
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            enemyHealth.DamageEnemy(dmg);
            
        }
    }
}
