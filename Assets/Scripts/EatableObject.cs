using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatableObject : MonoBehaviour
{
    [SerializeField]
    private float RestoreValue=0.125F; // what proportion of the meter is refilled, in [0,1]
    [SerializeField]
    public GameObject HungerMeter; 
    public GameObject Spawner;
    private RectTransform rt;
    private float MaxFill=550; // actual width of parent container
    private float ActualRestore;

    void Start() {
        ActualRestore = RestoreValue*MaxFill;
        rt = HungerMeter.GetComponent<RectTransform>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && rt.rect.width!=MaxFill) {
            float curWidth = rt.rect.width;
            // Cap hunger at max length of parent container
            float nextWidth = System.Math.Min(MaxFill, curWidth+ActualRestore);
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, nextWidth);
            Spawner.GetComponent<FoodSpawner>().FoodObjectCount--;    
        }
        Destroy(gameObject);
    }
}