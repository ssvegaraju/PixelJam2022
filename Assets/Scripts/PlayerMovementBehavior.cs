using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehavior : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private PlayerInput playerInput;
    private InputManager inputManager;

    [SerializeField] float aSpeed = 50f;
    [SerializeField] float maxSpeed = 8f;
    [SerializeField] int jumpCount = 2;
    [SerializeField] float jumpHeight = 45f;
    bool isDouble = false;
    bool jumpCut = false;
    [SerializeField] bool jumpReleased = true;
    // Start is called before the first frame update

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        inputManager = new InputManager();

        inputManager.PlayerMovementActionMap.Enable();
        inputManager.PlayerMovementActionMap.Jump.performed += releaseJump;
        //inputManager.PlayerMovementActionMap.Movement.performed += playerMovement;
        

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
            Vector2 jumpVector = moveVector;
            playerRigidbody.velocity = Vector2.ClampMagnitude(playerRigidbody.velocity, 0f);


            playerRigidbody.AddForce(jumpVector * jumpHeight, ForceMode2D.Impulse);
            jumpCount--;
            jumpReleased = false;
            jumpCut = false;

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

        if (((inputManager.PlayerMovementActionMap.Movement.ReadValue<Vector2>().x > 0) && (playerRigidbody.velocity.x < maxSpeed)) ||
            ((inputManager.PlayerMovementActionMap.Movement.ReadValue<Vector2>().x < 0) && (playerRigidbody.velocity.x > -maxSpeed)))
        {
            playerRigidbody.AddForce(moveVector * aSpeed, ForceMode2D.Force);
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
    }
}
