using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementBehavior : LivingEntity
{
    private Rigidbody2D playerRigidbody;
    private PlayerInput playerInput;
    private InputManager inputManager;
    private Animator anim;
    private SpriteRenderer spr;

    [SerializeField] float groundAccel = 50f;
    [SerializeField] float groundDecel = 50f;
    [SerializeField] float airAccel = 40f;
    [SerializeField] float airDecel = 40f;
    [SerializeField] float maxSpeed = 8f;
    int jumpCount = 2;
    [SerializeField] float jumpHeight = 45f;
    [SerializeField] float multiJumpHeight = 30f;
    [SerializeField] float bounceHeight = 30f;
    public int multiJumps = 1;
    bool jumpCut = false;
    bool firstJump = true;
    [SerializeField] bool jumpReleased = true;
    bool touchingGround = false;

    bool isInvincible = false;
    float endInvincibilityTime;
    public float invincibilityTime;

    public LayerMask whatIsGround;
    public BoxCollider2D boxCol;
    private bool isGrounded = false;

    private int lastDirection = 1;
    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake();
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
        CheckIfGrounded();
        Vector2 moveVector = inputManager.PlayerMovementActionMap.Movement.ReadValue<Vector2>();

        if(playerRigidbody.velocity.y < -35f)
        {
            playerRigidbody.velocity = Vector2.ClampMagnitude(playerRigidbody.velocity, 35f);
        }

        if(moveVector.y > 0 && jumpCount > 0 && jumpReleased && !isDead)
        {
            if(firstJump){
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
                jumpCut = false;
                firstJump = false;
            }
            else{
                playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, multiJumpHeight);
                jumpCut = true;
                jumpCount--;
            }
            //playerRigidbody.AddForce(jumpVector * jumpHeight, ForceMode2D.Impulse);
            jumpReleased = false;
            anim.SetBool("Falling", true);
            Debug.Log("JUMPING!");
            AudioManager.instance.Play("Jump");
            anim.SetTrigger("Jumping");
        }

        if(jumpReleased && playerRigidbody.velocity.y > 0 && !jumpCut)
        {
            Vector2 cutVelocity = playerRigidbody.velocity;
            cutVelocity.y = cutVelocity.y / 2f;
            playerRigidbody.velocity = cutVelocity;
            jumpCut = true;

            Debug.Log("JUMP RELEASED ABORT ABORT!");
        }
        int direction = (int)Math.Sign(moveVector.x);
        if (direction != lastDirection) {
            spr.flipX = !spr.flipX;
            lastDirection = direction;
        }
        float newXVelo = playerRigidbody.velocity.x;
        if(direction != 0){
            //Debug.Log(moveVector.x);
            if(isGrounded){
                newXVelo = playerRigidbody.velocity.x + groundAccel * direction * Time.fixedDeltaTime;
            }
            else{
                newXVelo = playerRigidbody.velocity.x + airAccel * direction * Time.fixedDeltaTime;
            }
            anim.SetBool("Walking", true);
        }
        else{
            if(Math.Abs(playerRigidbody.velocity.x) < 0.5){
                newXVelo = 0;
            }
            else if(isGrounded){
                newXVelo = playerRigidbody.velocity.x + groundDecel * -Math.Sign(playerRigidbody.velocity.x) * Time.fixedDeltaTime;
            }
            else{
                newXVelo = playerRigidbody.velocity.x + airDecel * -Math.Sign(playerRigidbody.velocity.x) * Time.fixedDeltaTime;
            }
            anim.SetBool("Walking", false);
        }
        playerRigidbody.velocity = new Vector2(Mathf.Clamp(newXVelo, -maxSpeed, maxSpeed), playerRigidbody.velocity.y);
        if (isDead){
            playerRigidbody.velocity = Vector2.zero;
        }
        /*
        if (((moveVector.x > 0) && (playerRigidbody.velocity.x < maxSpeed)) ||
            ((moveVector.x < 0) && (playerRigidbody.velocity.x > -maxSpeed)))
        {
            playerRigidbody.velocity = new Vector2(Mathf.Clamp(playerRigidbody.velocity.x + moveVector.x * groundAccel * Time.deltaTime, -maxSpeed, maxSpeed), playerRigidbody.velocity.y);
            anim.SetBool("Walking", true);
            
        } else {
            anim.SetBool("Walking", false);
        } */

        //Debug.Log("Calling Fixed Movement: " + moveVector);
        //Debug.Log("Calling Fixed Movement with velocity: " + playerRigidbody.velocity);
        anim.SetBool("Falling", playerRigidbody.velocity.y < 0f);
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
        jumpCount = multiJumps;
        firstJump = true;
        anim.SetBool("Falling", false);
        //Debug.Log("Reset");
    }

    public void Bounce(){
        playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, bounceHeight);
        jumpCut = true;
        AudioManager.instance.Play("Jump");
        jumpCount = multiJumps;
    }

    void CheckIfGrounded(){
        RaycastHit2D groundRaycastHit = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, .1f, whatIsGround);
        if (groundRaycastHit.collider != null)
        {
            isGrounded = true;
            resetJump();
        }
    }

    public override void TakeDamage(float damage)
    {
        if(endInvincibilityTime < Time.time){
            base.TakeDamage(damage);
            endInvincibilityTime = Time.time + invincibilityTime;
        }
    }

    public override void Die(){
        if(!isDead){
            isDead = true;
            spr.enabled = false;
            base.CallOnDeath();
            if(LevelLoaderScript.instance != null){
				LevelLoaderScript.instance.ReloadScene();
			}
            if(deathObject != null){
                Instantiate(deathObject, transform.position, transform.rotation);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Hazard"){
            TakeDamage(maxHealth);
        }
    }
}
