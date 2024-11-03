using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject FoodPrefab;
    public GameObject HungerMeter; 
    private float timer=0F;

    // Update is called once per frame
    void Update() {
        timer+=Time.deltaTime;
        if (timer>=1F) {
            GameObject food = Instantiate(FoodPrefab, transform.position, transform.rotation);   
            food.GetComponent<EatableObject>().HungerMeter = HungerMeter;
            timer=0F;
        }    
    }
}
