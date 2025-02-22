
using UnityEngine;


public class SculpinMovement : MonoBehaviour
{

    public int clock = 0;
    public int attackTimeout = 500;
    Collider2D jumpTrigger;
    Rigidbody2D rb;
    //public float jumpAngle;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        jumpTrigger = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        clock++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (PlayerCheck(collision))
        {
            Vector2 target = collision.transform.position - this.transform.position;
            attack(target);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (PlayerCheck(collision))
        {
            Vector2 target = collision.transform.position - this.transform.position;
            attack(target);
        }
    }

    bool PlayerCheck(Collider2D collison)
    {
        if (collison.CompareTag("Player") && clock > attackTimeout)
        {
            Transform playerTransform = collison.transform.Find("Alevin");
            if (playerTransform && playerTransform.gameObject.activeInHierarchy)
            {
                clock = 0;
                return true;
            }
            return false;
        }
        return false;
    }
    void attack(Vector2 target)
    {
        //float xComponent = Mathf.Sin(jumpAngle) * jumpForce;
        //float yComponent = Mathf.Cos(jumpAngle) * jumpForce;
        //print("attacking: Xc: " + xComponent + ", " + yComponent);
        print("attacking: " + target);
        //rb.AddForce(new Vector2(xComponent, yComponent), ForceMode2D.Impulse);
        rb.AddForce(target*jumpForce, ForceMode2D.Impulse);

    }

    void settle()
    {

    }
}
