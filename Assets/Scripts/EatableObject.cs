using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableObject : MonoBehaviour
{
    [SerializeField]
    private float RestoreValue=0.125F; // what proportion of the meter is refilled, in [0,1]
    [SerializeField]
    private GameObject HungerMeter; 

    void Start() {
        print("Start eatable " + gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        print("Collision:" + other.GetComponent<Collider2D>().name);
        if (other.gameObject.CompareTag("Player")) {
            RectTransform rt = HungerMeter.GetComponent<RectTransform>();
            float curWidth = rt.rect.width;
            float nextWidth = curWidth*(1+RestoreValue);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, nextWidth);
        }
    }
}