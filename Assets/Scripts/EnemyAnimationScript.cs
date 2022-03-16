using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationScript : MonoBehaviour
{
    EnemyBase parentEnemy;

    private void Start()
    {
        parentEnemy = GetComponentInParent<EnemyBase>();
    }

    public void triggerDeath()
    {
        parentEnemy.Die();
    }
}
