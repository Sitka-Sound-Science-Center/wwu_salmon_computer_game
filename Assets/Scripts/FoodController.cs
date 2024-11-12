using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class FoodController : MonoBehaviour
{
    [SerializeField]
    private int MaxFoodObjects=10;
    [SerializeField]
    private float spawndelay;
    public GameObject FoodPrefab;
    public GameObject HungerMeter;
    private float xMin, xMax, yMin, yMax;
    private Vector3 position;
    public int FoodObjectCount=0;
    private float counter;

    // Start is called before the first frame update
    void Start() {
        RectTransform MoveableArea = GetComponent<RectTransform>();
        float rectX = MoveableArea.rect.x + MoveableArea.position.x; //left edge of transform
        float rectY = MoveableArea.rect.y + MoveableArea.position.y; //bottom edge of transform
        Vector2 area = MoveableArea.sizeDelta;
        xMin = rectX;
        xMax = rectX + area.x;
        yMin = rectY;
        yMax = rectY + area.y;
        //FoodPrefab = Resources.Load<GameObject>("plankton");
    }

    // Update is called once per frame
    void Update() {
        if(FoodObjectCount < MaxFoodObjects && counter>=spawndelay) {
            FoodObjectCount++;
            GameObject food = Instantiate(FoodPrefab, newPosition(), Quaternion.identity,this.transform);
            counter=0;
        }
        countChildren();
    }

    private void FixedUpdate() {
        counter+=Time.deltaTime;
    }

    private Vector3 newPosition() {
        position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0f);
        return position;
    }

    private void countChildren() {
        FoodObjectCount = GetComponentsInChildren<Transform>().Length -1;
    }
}
