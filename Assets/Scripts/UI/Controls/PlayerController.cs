using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Player playerInput;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField]
    private float playerSpeed = 10f;
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = 0f;
    Vector3 scale;
    float smooth = 5.0f;
    float flip = 0;
    private void Awake()
    {
        playerInput = new Player();
        controller = GetComponent<CharacterController>();
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

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, movementInput.y,0f);
        float tiltAroundZ = Mathf.Atan2(movementInput.x, movementInput.y) * Mathf.Rad2Deg;

        if(move.x < 0f)
        {
            flip = -1;
        }
        else
        {
            flip = 1;  
        }

        //Quaternion rotation = Quaternion.Euler(0, 0, tiltAroundZ - 180 + (flip*180));
        //transform.localScale = new Vector3(scale.x * flip, scale.y, scale.z);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smooth);
        controller.Move(move * Time.deltaTime * playerSpeed);
        



        



        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
