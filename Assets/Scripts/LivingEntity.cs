using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour, IDamagable
{
    public float health {get; protected set;}
    public float maxHealth = 3;
    public GameObject deathObject;
    protected bool isDead = false;
    public event System.Action OnDeath;
    protected virtual void Awake(){
        health = maxHealth;
    }

    public virtual void TakeDamage(float damage){
        health -= damage;
        if(health <= 0 && !isDead){

            Die();
        }
        
    }

    public virtual void Die(){
        //CameraScript.instance.Shake(deathShakeDuration, deathShakeMagnitude);
        
        isDead = true;
        if(deathObject != null){
            Destroy(Instantiate(deathObject, transform.position, Quaternion.identity), 1f);
        }
        if(OnDeath != null){
            OnDeath();
        }
        AudioManager.instance.Play("Death");
        Destroy(gameObject);
    }

    protected virtual bool CheckOnDeathNull(){
        return OnDeath == null;
    }

    protected virtual void CallOnDeath(){
        if(OnDeath != null){
            OnDeath();
        }
        
    }
}
