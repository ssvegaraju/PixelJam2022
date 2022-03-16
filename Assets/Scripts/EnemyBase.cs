using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : LivingEntity
{
    public float damage = 1f;

    // If we added animation death to all enemies, Uncomment this.
    //public override void TakeDamage(float damage)
    //{
    //    health -= damage;
    //    if (health <= 0 && !isDead)
    //    {
    //        Animator anim = GetComponentInChildren<Animator>();
    //        anim.SetBool("isDead", true);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            LivingEntity playerHealth = GetComponentInParent<LivingEntity>();
            if(playerHealth != null){
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
