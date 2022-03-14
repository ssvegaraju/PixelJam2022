using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderBehavior : MonoBehaviour
{
    PlayerMovementBehavior thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        thePlayer = GetComponentInParent<PlayerMovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            thePlayer.resetJump();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            thePlayer.resetJump();
        }
    }


}
