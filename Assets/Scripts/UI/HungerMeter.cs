using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerMeter : MonoBehaviour
{
    public float startingWidth;
    public float startingHeight;

    private void Start()
    {
        //startingWidth = transform.localScale.x;
        startingWidth = 550;
        startingHeight = 76;
    }

    public void SetMeterSize(float val)
    {
        gameObject.GetComponent<Slider>().maxValue = val;
        GetComponent<RectTransform>().sizeDelta = new Vector2(startingWidth * val, startingHeight);
    }

    public void EatFish(float value)
    {
        gameObject.GetComponent<Slider>().value += value;
    }

    public void TakeDamage(float value)
    {
        gameObject.GetComponent<Slider>().value -= value;
    }
}
