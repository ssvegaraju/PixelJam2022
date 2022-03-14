using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehavior : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private PlayerInput playerInput;
    private InputManager inputManager;
    private Animator anim;
    private SpriteRenderer spr;

    [SerializeField] float aSpeed = 50f;
    [SerializeField] float maxSpeed = 8f;
    [SerializeField] int jumpCount = 2;
    [SerializeField] float jumpHeight = 45f;
    bool isDouble = false;
    bool jumpCut = false;
    [SerializeField] bool jumpReleased = true;

    private int lastDirection = 1;
    // Start is called before the first frame update

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        inputManager = new InputManager();

        inputManager.PlayerMovementActionMap.Enable();
        inputManager.PlayerMovementActionMap.Jump.performed += releaseJump;
        //inputManager.PlayerMovementActionMap.Movement.performed += playerMovement;

        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Vector2 moveVector = inputManager.PlayerMovementActionMap.Movement.ReadValue<Vector2>();

        if(playerRigidbody.velocity.y < -35f)
        {
            playerRigidbody.velocity = Vector2.ClampMagnitude(playerRigidbody.velocity, 35f);
        }

        if(inputManager.PlayerMovementActionMap.Movement.ReadValue<Vector2>().y > 0 && jumpCount > 0 && jumpReleased)
        {
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);


            //playerRigidbody.AddForce(jumpVector * jumpHeight, ForceMode2D.Impulse);
            jumpCount--;
            jumpReleased = false;
            jumpCut = false;
            anim.SetBool("Falling", true);
            Debug.Log("JUMPING!");
        }

        if(jumpReleased && playerRigidbody.velocity.y > 0 && !jumpCut)
        {
            Vector2 cutVelocity = playerRigidbody.velocity;
            cutVelocity.y = cutVelocity.y / 2f;
            playerRigidbody.velocity = cutVelocity;
            jumpCut = true;

            Debug.Log("JUMP RELEASED ABORT ABORT!");
        }
        int direction = (int)Mathf.Sign(moveVector.x);
        if (direction != lastDirection) {
            spr.flipX = !spr.flipX;
            lastDirection = direction;
        }
        if (((inputManager.PlayerMovementActionMap.Movement.ReadValue<Vector2>().x > 0) && (playerRigidbody.velocity.x < maxSpeed)) ||
            ((inputManager.PlayerMovementActionMap.Movement.ReadValue<Vector2>().x < 0) && (playerRigidbody.velocity.x > -maxSpeed)))
        {
            playerRigidbody.velocity = new Vector2(Mathf.Clamp(playerRigidbody.velocity.x + moveVector.x * aSpeed * Time.deltaTime, -maxSpeed, maxSpeed), playerRigidbody.velocity.y);
            anim.SetBool("Walking", true);
            
        } else {
            anim.SetBool("Walking", false);
        }

        //Debug.Log("Calling Fixed Movement: " + moveVector);
        //Debug.Log("Calling Fixed Movement with velocity: " + playerRigidbody.velocity);
    }

    public void releaseJump(InputAction.CallbackContext context)
    {
        jumpReleased = true;
    }

    public void playerDrop()
    {

        Debug.Log("Dropping!");
    }

    public void resetJump()
    {
        if (isDouble)
        {
            jumpCount = 2;
        }
        else
        {
            jumpCount = 1;
        }
        anim.SetBool("Falling", false);
    }
}
