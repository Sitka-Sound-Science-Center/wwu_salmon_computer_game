using Codice.Client.BaseCommands;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using UnityEngine.UIElements;

public class SculpinMovement : MonoBehaviour
{

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 target = collision.transform.position - this.transform.position;
            attack(target);
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector2 target = collision.transform.position - this.transform.position;
            attack(target);
        }
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
