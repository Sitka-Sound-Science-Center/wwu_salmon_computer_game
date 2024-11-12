using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerMeter : MonoBehaviour
{
    [SerializeField] 
    private float EmptyTime=10F; // time in seconds needed for bar to go from full to empty
    private float MaxFill=550; // actual width of parent container
    private float timer=0F;
    private RectTransform rt;

    void Start() {
        rt = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update() {
        float curWidth = rt.rect.width;
        timer+=Time.deltaTime;
        if (curWidth>=0) { // no underflow on resources
            float nextWidth = System.Math.Max(0,curWidth-(MaxFill*(Time.deltaTime/EmptyTime)));
            // why cant it just be as simple as calling max() ???
            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, nextWidth);
        }
        if (timer>=2.5F) {
            print("Current width: " + rt.rect.width);
            timer=0F;
        }
    }
}
