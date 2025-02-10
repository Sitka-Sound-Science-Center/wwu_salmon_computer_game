using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerMeter : MonoBehaviour
{
    [SerializeField] 
    //private float EmptyTime=10F; // time in seconds needed for bar to go from full to empty
    //private float MaxFill=550; // actual width of parent container
    private float timer=0F;
    //private RectTransform rt;

    void Start() {
        //rt = gameObject.GetComponent<RectTransform>();
    }

    void Update() {
        //timer+=Time.deltaTime;

        //if (timer>=2.5F) {
        //    timer=0F;
        //}
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
