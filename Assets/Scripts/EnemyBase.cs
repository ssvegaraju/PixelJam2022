using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : LivingEntity
{
    public float damage = 1f;

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            LivingEntity playerHealth = GetComponentInParent<LivingEntity>();
            if(playerHealth != null){
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
