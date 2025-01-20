using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CollideEvent : MonoBehaviour
{
    public UnityEvent onCollide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            onCollide.Invoke();
        }
    }
}
