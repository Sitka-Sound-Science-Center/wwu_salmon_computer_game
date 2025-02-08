using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerS : MonoBehaviour
{
    [SerializeField]
    private float playerSpeedS = 10;
    [SerializeField]
    private float maxSpeed = 10;
    private bool isGrounded;
    Rigidbody rb3;
    Player player;

    public Vector3 JumpPowerVector = new Vector3(10f, 12f, 0f);



    // Start is called before the first frame update
    void Start()
    {
        rb3 = GetComponent<Rigidbody>();
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
        
        rb3.AddForce(GetInput(player), ForceMode.Impulse);
        rb3.velocity = clampSpeed(rb3.velocity, maxSpeed);
        
        
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
        if (playerInput.PlayerMain.Jump.IsPressed() && isGrounded && rb3.velocity.x > 0)
        {
            isGrounded = false; //change to raycast?
            print("Jump");
            //ycomp += jumpPower;
            rb3.AddForce(JumpPowerVector, ForceMode.Impulse);
        }
        Vector3 move = new Vector3(0f, 0f, 0f);
        //Vector3 move = new Vector3(movementInput.x * playerSpeed, ycomp, movementInput.y * playerSpeed);
        //print(move);
        if (isGrounded)
        {
            move = new Vector3(movementInput.x * playerSpeedS, ycomp, movementInput.y * playerSpeedS);
            move = clampSpeed(move, 0f);
        }
        return move;
    }

    private Vector3 clampSpeed(Vector3 move, float clampValue)
    {
        //positive speed cap
        if (rb3.velocity.x > maxSpeed)
        {
            move.x = clampValue;
        }
        if(rb3.velocity.y > maxSpeed)
        {
            move.y = clampValue;
        }
        if(rb3.velocity.z > maxSpeed)
        {
            move.z = clampValue;
        }
        //negative speed cap
        if (rb3.velocity.x < -maxSpeed)
        {
            move.x = -clampValue;
        }
        if (rb3.velocity.y < -maxSpeed)
        {
            move.y = -clampValue;
        }
        if (rb3.velocity.z < -maxSpeed)
        {
            move.z = -clampValue;
        }
        return move;
    }

    public void disablePlayer(string reason)
    {
        player.Disable();
        UnityEngine.Time.timeScale = 0;
        GameObject.Find("UICanvas/DeathScreens/" + reason).SetActive(true);
    }
}
