using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeredMusicProgression : MonoBehaviour
{

    public LayerMusic[] layers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class LayerMusic {
    public float yHeightToStartAt = 0f;
    public string audioClipName;
}
