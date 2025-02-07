using PlasticGui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerS : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float swimUpPower;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float maxSpeed;
    private bool isGrounded;
    Rigidbody rb;
    Player player;

    public Vector3 JumpPowerVector;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = new Player();
        player.Enable();
}

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMove();    
    }

    private void HandleMove()
    {
        
        rb.AddForce(GetInput(player), ForceMode.Impulse);
        rb.velocity = clampSpeed(rb.velocity, maxSpeed);
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            isGrounded = true;
        }
    }
    private Vector3 GetInput(Player playerInput)
    {
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        float ycomp = 0;
        if (playerInput.PlayerMain.SwimUp.IsPressed())
        {
            print("SwimUP");
            ycomp += swimUpPower;
        }
        if (playerInput.PlayerMain.Jump.IsPressed() && isGrounded && rb.velocity.x > 0)
        {
            isGrounded = false; //change to raycast?
            print("Jump");
            //ycomp += jumpPower;
            rb.AddForce(JumpPowerVector, ForceMode.Impulse);
        }
        Vector3 move = new Vector3(0f, 0f, 0f);
        //Vector3 move = new Vector3(movementInput.x * playerSpeed, ycomp, movementInput.y * playerSpeed);
        //print(move);
        if (isGrounded)
        {
            move = new Vector3(movementInput.x * playerSpeed, ycomp, movementInput.y * playerSpeed);
            move = clampSpeed(move, 0f);
        }
        return move;
    }

    private Vector3 clampSpeed(Vector3 move, float clampValue)
    {
        //positive speed cap
        if (rb.velocity.x > maxSpeed)
        {
            move.x = clampValue;
        }
        if(rb.velocity.y > maxSpeed)
        {
            move.y = clampValue;
        }
        if(rb.velocity.z > maxSpeed)
        {
            move.z = clampValue;
        }
        //negative speed cap
        if (rb.velocity.x < -maxSpeed)
        {
            move.x = -clampValue;
        }
        if (rb.velocity.y < -maxSpeed)
        {
            move.y = -clampValue;
        }
        if (rb.velocity.z < -maxSpeed)
        {
            move.z = -clampValue;
        }
        return move;
    }

    public void disablePlayer()
    {
        player.Disable();
    }
}
