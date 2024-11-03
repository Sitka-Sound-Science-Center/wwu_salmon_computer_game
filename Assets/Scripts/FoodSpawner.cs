using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{   
    [SerializeField]
    private int MaxFoodObjects=10;
    public GameObject FoodPrefab;
    public GameObject HungerMeter;
    public int FoodObjectCount=0;
    private float x_min, x_max;
    private float timer=0F;

    void Start() {
        float parentX = transform.parent.transform.position.x;
        x_min = parentX-100;
        x_max = parentX+100;
    }
    
    // Update is called once per frame
    void Update() {
        timer+=Time.deltaTime;
        if (timer>=3F && FoodObjectCount<MaxFoodObjects) {
            float randX = Random.Range(x_min, x_max);
            Vector3 newPos = new Vector3(randX, transform.position.y, transform.position.z);
            GameObject food = Instantiate(FoodPrefab, transform.position, transform.rotation);   
            food.GetComponent<EatableObject>().HungerMeter = HungerMeter;
            food.GetComponent<EatableObject>().Spawner = gameObject;
            FoodObjectCount++;
            timer=0F;
        }    
    }
}
