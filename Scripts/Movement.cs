using UnityEngine;

// DISCLAIMER!!! Not my script! 

public class Movement : MonoBehaviour
{
    // Sets a bunch variables which is used later and changeable in the inspector
    public float moveSpeed;
    public float groundDrag;
    public float walking;
    public float running;
    public float jumpForce;
    public float jumpCD;
    public float airMultiplier;
    public bool jumpReady;
    
    
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;
    
    
    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 moveDirection;

    // also access the rigidbody of the gameobject
    private Rigidbody rb;

    private void Start()
    {
        // starts the game with getting the rigidbody, and freeze its rotation (doesnt matter since its a capsule)
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        // Makes the players movement speed higher if leftshit is held down.
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = running;
        }
        else
        {
            moveSpeed = walking;
        }
        
        // This helps the program determine how much drag should be on the players RB,
        // when he is either on the ground or in the air
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
        
        // Makes all the listed methods run at all times, and make it more manageable to 
        // just call methods instead of have them all in the fixedupdate
        SpeedControl();
        MyInput();
        MovePlayer();
    }
    
    private void MyInput()
    {
        // Gets the players WASD input, the horizontal and vertical (not actually vertical,
        // its the z-axis substitute) axis
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        // Checks whether or not the player is ready to junp, and  then jump with spacebar
        if (Input.GetKey(KeyCode.Space) && jumpReady && grounded)
        {
            // Makes the player jump and incapable of jumping again when in the air
            jumpReady = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCD);
        }
    }

    private void MovePlayer()
    {
        // Takes the previous recorded input and puts it into the 3Dvector moveDirection
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // moves the player, and if in the air, move with the airmultiplier (basically move around with half speed)
        if (grounded)
        { 
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        } else if (!grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
        
    }

    private void SpeedControl()
    {
        // this makes sure that the player object doesn't increase their movement speed to a billion miles an hour
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        // basically speed control... DONT EXCEED!!
        if (flatVel.magnitude > moveSpeed)
        {
            // If it exceeds... Slow it down :) 
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // the vertical velocity is set to 0 in order for the jump to start from a stationary position on the y axis.
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        
        // gives the player force, and makes it simulate a jump, in the up direction
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        // sets the jumpReady bool to true
        // this gets called after the player jump
        jumpReady = true;
    }
    
}
