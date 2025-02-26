using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Public: 
    public HungerMeter hungerMeter;

    // Private
    [SerializeField]
    private GameObject DeathScreenParent;
    [SerializeField]
    private float playerSpeed = 11f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = 0f;

    private Player playerInput;
    private Vector3 playerVelocity;
    private Vector3 move;
    private Vector3 scale;
    private Rigidbody2D rb;
    float smooth = 5.0f;
    float flip = 0;
    float lastflip = 0;
    bool groundedPlayer;

    private void Awake() {
        playerInput = new Player();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        playerInput.Enable();
    }

    private void OnDisable() {
        playerInput.Disable();
    }

    private void Start() {
       scale = transform.localScale;
       hungerMeter = GameObject.FindWithTag("HMeter").GetComponent<HungerMeter>();
    }

    private void FixedUpdate() {
        HandleMove();
    }

    private void HandleMove() {
        rb.AddForce(move, ForceMode2D.Impulse);
    }

    void Update() {
        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        move = new Vector3(movementInput.x*playerSpeed, movementInput.y*playerSpeed,0f);
        float tiltAroundZ = Mathf.Atan2(movementInput.y , movementInput.x) * Mathf.Rad2Deg;
        if (move.x < 0f) flip = -1;
        else flip = 1;   

        Quaternion rotation = Quaternion.Euler(0, 0, tiltAroundZ - 180 + (flip * 180));
        if (lastflip != flip) transform.rotation = rotation;
        lastflip = flip;

        transform.localScale = new Vector3(scale.x, scale.y * flip, scale.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * smooth);

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer) {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
    }

    //Methods for unit test
    public float getPlayerSpeed() {
        return playerSpeed;
    }

    // Handle food interactions: increase health bar and destroy food obj
    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Food")) {
            EatableObject FoodScript = other.GetComponent<EatableObject>();
            hungerMeter.EatFish(FoodScript.GetRestoreValue());
            Destroy(other);
        }
    }

    // Handle predator interactions: die and display death screen
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Predator")) {
            float actualDamage = other.gameObject.GetComponent<DeathReason>().ac;
            if (hungerMeter.GetComponent<Slider>().value <= 0) {
                string reason = other.gameObject.GetComponent<DeathReason>().reason; 
                killPlayer(reason);
            }
            else hungerMeter.TakeDamage(actualDamage);
        }
    }

    public void killPlayer(string reason) {
        UnityEngine.Time.timeScale = 0;
        GameObject.Find("UICanvas/DeathScreens/" + reason).SetActive(true);
    }
}
