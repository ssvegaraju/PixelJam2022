using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPatrollerEnemy : MonoBehaviour
{
    public float speed;
    public float rayDistance = 2f;
    private bool movingRight = true;

    private Rigidbody2D rb;
    public Transform groundDetection;
    public GameObject enemyGFX;
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDistance);
        if(groundInfo.collider == false){
            Flip();
        }
    }

    void FixedUpdate(){
        float currentVelocity = speed;
        if(!movingRight){
            currentVelocity = -1 * speed;
        }
        rb.velocity = new Vector2(currentVelocity, rb.velocity.y);
    }

    void Flip(){
        movingRight = !movingRight;

        Vector3 theScale = enemyGFX.transform.localScale;
		theScale.x *= -1;
		enemyGFX.transform.localScale = theScale;
    }
}
