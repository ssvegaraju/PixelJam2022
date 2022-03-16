using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed = 5f;
    public Transform[] patrolPoints;
    public float waitTime;
    private float startMoveTime;
    private int currentPointIndex = 0;
    bool isMoving = true;
    Vector2 velocity = Vector2.zero;

    private void FixedUpdate(){
        if(isMoving){
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.fixedDeltaTime);
            if((Vector2)transform.position == (Vector2)patrolPoints[currentPointIndex].position){
                isMoving = false;
                startMoveTime = Time.time + waitTime;
                Debug.Log("Stop");
            }
        }
        else if(startMoveTime < Time.time){
            Debug.Log("Start Moving again");
            isMoving = true;
            currentPointIndex++;
            if(currentPointIndex >= patrolPoints.Length){
                currentPointIndex = 0;
            }
        }
    }
}
