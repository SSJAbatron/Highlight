using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody2D playerRigidBody;


    // move variables
    private float horizontal;
    private float speed = 10f;
    private bool isFacingRight = true;

    //player anim component
    private Animator playerAnim;

    // player walk audio source
    private AudioSource playerWalk;

    //jump variables
    private float jumpForce = 15f;
    private float fallSpeed = 3f;
    private Vector2 gravity;
    public Transform groundCheck;
    public LayerMask platformLayer;

    // Start is called before the first frame update
    void Start()
    {
        gravity = new Vector2(0,-Physics2D.gravity.y);
        playerAnim= GetComponent<Animator>();
        playerWalk = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // moving along the x axis and retaining the y axis as such
        playerRigidBody.velocity = new Vector2(horizontal * speed, playerRigidBody.velocity.y);
        if (!playerWalk.isPlaying)
        {
            playerWalk.Play();
        }
        playerAnim.SetBool("IsRunning", true);
        // flip player direction
        // turn left, if player is facing right and moves left
        if (isFacingRight && horizontal < 0f)
        {
            FlipSpriteDirection();
        }
        // turn right, if the player is facing left and moves right
        else if (!isFacingRight && horizontal > 0f)
        {
            FlipSpriteDirection();
        }  
        // player falls down faster when in air
        if (playerRigidBody.velocity.y < 0f)
        {
            playerRigidBody.velocity -= gravity * fallSpeed * Time.deltaTime;
        }
        if(playerRigidBody.velocity == new Vector2(0, playerRigidBody.velocity.y) || !IsOnPlatform())
        {
            playerAnim.SetBool("IsRunning", false);
            if (playerWalk.isPlaying)
            {
                playerWalk.Pause();
            }
        }
    }
    
    //  to flip the player sprite and all the child objects under it
    private void FlipSpriteDirection()
    {
        // based on the current value it has to be set to its opposite when the flip happens
        isFacingRight = !isFacingRight;
        // get players current local scale
        Vector3 localScale = transform.localScale;
        // flip along the x axis or invert along the x axis
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public bool IsOnPlatform()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, platformLayer);
    }

    // left and right movement, get user input
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    // jump action
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsOnPlatform())
        {
            // do jump
            AudioManager.instance.PlaySFX("Jump");
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
        }
        // in the air
        
        if(context.canceled && playerRigidBody.velocity.y > 0f)
        {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x,playerRigidBody.velocity.y * 0.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform" && collision.gameObject.GetComponent<PlatformBehaviour>().hasPassed == false)
        {
            GameManager.instance.UpdateScore();
            collision.gameObject.GetComponent<PlatformBehaviour>().hasPassed = true;
        }
    }

}
