using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage = 1f;
    public bool destroyOnGround = false;
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            LivingEntity playerHealth = GetComponentInParent<LivingEntity>();
            if(playerHealth != null){
                playerHealth.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        else if(other.tag == "Ground" && destroyOnGround){
            Destroy(gameObject);
        }
    }
}
