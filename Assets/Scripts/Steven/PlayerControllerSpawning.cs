
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerSpawning : MonoBehaviour
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
    [SerializeField]
    private RectTransform rect;
    Vector3 scale;
    float smooth = 5.0f;
    float flip = 0;
    float lastflip = 0;
    private Rigidbody2D rb;
    private Vector3 move;
    private float xrot;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    [SerializeField]
    private float scaleMin;
    [SerializeField]
    private float scaleMax;
    //hunger meter elements
    public GameObject HungerMeter;
    private RectTransform rt;
    private float MaxFill = 550; // actual width of parent container
    private float ActualRestore;
    private GameObject adult;

    [SerializeField]
    GameObject DeathScreenParent;

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
        adult = GameObject.Find("CohoSpawning1");
        getRectSpace(rect);
        xrot = transform.rotation.x;
        scale = transform.localScale;
        //HungerMeter = GameObject.FindWithTag("HMeter");
        //rt = HungerMeter.GetComponent<RectTransform>();
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
        handleScale();
        //groundedPlayer = controller.isGrounded;
        //if (groundedPlayer && playerVelocity.y < 0)
        //{
        //    playerVelocity.y = 0f;
        /// /}
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        move = new Vector3(movementInput.x * playerSpeed, movementInput.y * playerSpeed, 0f);



        float tiltAroundZ = Mathf.Atan2(movementInput.y, movementInput.x) * Mathf.Rad2Deg;
        //print("tilt: " + tiltAroundZ + "  movement vec:" + movementInput);

        if (move.x < 0f)
        {
            flip = -1;
        }
        else
        {
            flip = 1;

        }

        Quaternion rotation = Quaternion.Euler(xrot, 0, tiltAroundZ - 180 + (flip * 180));
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

    // Handle food interactions: increase health bar and destroy food obj
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Food") && rt.rect.width != MaxFill)
        {
            EatableObject FoodScript = other.GetComponent<EatableObject>();
            float curWidth = rt.rect.width;
            float ActualRestore = FoodScript.GetRestoreValue();
            // Cap hunger at max length of parent container
            float nextWidth = System.Math.Min(MaxFill, curWidth + ActualRestore);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, nextWidth);
            FoodScript.Spawner.GetComponent<FoodController>().FoodObjectCount--;
            Destroy(other);
        }
    }

    // Handle predator interactions: die and display death screen
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Predator"))
        {
            ActualRestore = other.gameObject.GetComponent<DeathReason>().ac;
            float curWidth = rt.rect.width;
            float nextWidth = curWidth - ActualRestore;
            if (nextWidth <= 0)
            {

                string reason = other.gameObject.GetComponent<DeathReason>().reason;
                killPlayer(reason);
            }
            else
            {
                rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, nextWidth);
            }
        }
    }

    public void killPlayer(string reason)
    {
        UnityEngine.Time.timeScale = 0;
        GameObject.Find("UICanvas/DeathScreens/" + reason).SetActive(true);
    }
    private void getRectSpace(RectTransform rect)
    {
        
        float rectX = rect.rect.x + rect.position.x; //left edge of transform
        float rectY = rect.rect.y + rect.position.y; //bottom edge of transform
        Vector2 area =rect.sizeDelta;
        xMin = rectX;
        xMax = rectX + area.x;
        yMin = rectY;
        yMax = rectY + area.y;
        print("ymin,ymax: " + yMin + ", " + yMax);
    }

    private void handleScale()
    {
        //get y position in rect
        if (transform.position.y > yMin && transform.position.y < yMax)
        {
            float scaleFactorN = normalize(yMin, yMax, transform.position.y);
            //normalize
            print("ScaleFactorN" + scaleFactorN);
            //adjust for scale factor
            //scale player sprite
            Vector3 newScale = new Vector3 (scaleFactorN, scaleFactorN, 1f);
            print("NewScale: " + newScale);
            adult.transform.localScale = newScale;
        }
        }
    
    private float normalize(float min, float max, float input)
        {
            float top = scaleMax;//b
            float bottom = scaleMin; //a
            float result = (input - max)*(top - bottom);
            result = result / (min - max);
            result = result + bottom;
            return result;
        }
}
