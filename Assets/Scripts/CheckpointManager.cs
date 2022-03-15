using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    public CheckpointScript[] checkpoints;
    void Awake(){
        instance = this;
        for(int i = 0; i < checkpoints.Length; i++){
            checkpoints[i].SetCheckpointNumber(i);
        }
    }
}
