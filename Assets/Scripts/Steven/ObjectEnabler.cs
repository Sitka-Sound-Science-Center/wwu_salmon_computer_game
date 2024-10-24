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
        Rigidbody2D comp;
        if (collision.TryGetComponent(out comp))
        {
            comp.isKinematic = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D comp;
        if (collision.TryGetComponent(out comp))
        {
            comp.isKinematic = true;
            comp.velocity = Vector3.zero;
            comp.angularVelocity = 0;
        }
    }
}
