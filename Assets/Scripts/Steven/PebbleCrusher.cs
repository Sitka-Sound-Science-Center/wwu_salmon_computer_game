using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PebbleCrusher : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Pebble"))
        {
            print("pebble detected");
            CircleCollider2D component;
            if (collision.TryGetComponent(out component))
            {
                //if pebble and has collider2D
                //disable just the circle collider, NOT the polygon collider
                component.enabled = false;
            }
        }
    }
}
