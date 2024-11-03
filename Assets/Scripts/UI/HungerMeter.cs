using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerMeter : MonoBehaviour
{
    [SerializeField] 
    private float DepletionSpeed=0.125F; // in [0,1], is the amount the bar decreases each frame

    // Update is called once per frame
    void Update() {
        RectTransform rt = gameObject.GetComponent<RectTransform>();
        float curWidth = rt.rect.width;
        // not sure how to update this so the comment on DepletionSpeed is observed behavior
        //float nextWidth = curWidth*(1-DepletionSpeed);
        //rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, nextWidth);
    }
}
