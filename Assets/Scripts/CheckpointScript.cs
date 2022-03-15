using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    int checkpointNumber = -1;
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && checkpointNumber != -1){
            LevelLoaderScript.instance.SetCurrentCheckpoint(checkpointNumber);
        }
    }

    public void SetCheckpointNumber(int number){
        checkpointNumber = number;
    }
}
