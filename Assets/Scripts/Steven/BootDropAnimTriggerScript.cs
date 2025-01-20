using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Rigidbody))]
public class BootDropAnimTriggerScript : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    private Rigidbody2D rb;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("collision detected");
            rb.isKinematic = false;    
        }
    }
}
