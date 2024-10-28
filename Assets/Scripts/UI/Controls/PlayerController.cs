using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;

//using TreeEditor;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    private Player playerInput;
    //private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 11f;
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = 0f;
    Vector3 scale;
    float smooth = 5.0f;
    float flip = 0;
    float lastflip = 0;
    private Rigidbody2D rb;
    private Vector3 move;
    private void Awake()
    {
        playerInput = new Player();
        //controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
       scale = transform.localScale;
    }

    private void FixedUpdate()
    {
        HandleMove();
    }

    private void HandleMove()
    {
        rb.AddForce(move, ForceMode2D.Impulse);
        
    }

    void Update()
    {
        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
       /// /}
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        
        move = new Vector3(movementInput.x*playerSpeed, movementInput.y*playerSpeed,0f);
        

        float tiltAroundZ = Mathf.Atan2(movementInput.y , movementInput.x) * Mathf.Rad2Deg;
        //print("tilt: " + tiltAroundZ + "  movement vec:" + movementInput);
        
        if (move.x < 0f)
        {
            flip = -1;
        }
        else
        {
            flip = 1;
 
        }

        

        Quaternion rotation = Quaternion.Euler(0, 0, tiltAroundZ - 180 + (flip * 180));
        if (lastflip != flip)
        {
            transform.rotation = rotation;
        }

        lastflip = flip;


        transform.localScale = new Vector3(scale.x, scale.y * flip, scale.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smooth);
        
        



        



        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        //controller.Move(playerVelocity * Time.deltaTime);
    }

    //Methods for unit test
    public float getPlayerSpeed()
    {
        return playerSpeed;
    }
}
