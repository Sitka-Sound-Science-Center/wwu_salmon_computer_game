using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent (typeof(Rigidbody))]
public class BootDropAnimTriggerScript : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            print("collision detected");
            //anim.SetTrigger("DropBoot");
            rb.isKinematic = false;    
        }
    }
}
