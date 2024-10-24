using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponentInChildren<Rigidbody2D>().isKinematic = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.gameObject.GetComponentInChildren<Rigidbody2D>().isKinematic = true;
        collision.gameObject.GetComponentInChildren<Rigidbody2D>().velocity = Vector3.zero;
        collision.gameObject.GetComponentInChildren<Rigidbody2D>().angularVelocity = 0;
    }
}
