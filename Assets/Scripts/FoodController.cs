using UnityEngine;

public class FoodController : MonoBehaviour
{
    public int MaxFoodObjects=10;
    public float spawndelay;
    public GameObject[] FoodPrefab;
    public GameObject HungerMeter;
    public int FoodObjectCount=0;
    private float counter;
    private float xMin, xMax, yMin, yMax;
    private Vector3 position;

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
        for(int i = 0; i < MaxFoodObjects; i++)
        {
            //plankton init position:
            Vector3 startPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0f);
            int foodIndex = i % FoodPrefab.Length;
            GameObject food = Instantiate(FoodPrefab[foodIndex], startPos , Quaternion.identity, this.transform);
            food.transform.position = startPos;
            
        }

    }

    private void FixedUpdate() {
        CountChildren(); // what? isnt the foodobjectcount++ line doing this?   
        if (FoodObjectCount < MaxFoodObjects && counter >= spawndelay)
        {
            FoodObjectCount++;
            int foodIndex = FoodObjectCount % FoodPrefab.Length;
            GameObject food = Instantiate(FoodPrefab[foodIndex], NewPosition(), Quaternion.identity, this.transform);
            counter = 0;
        }
        
        counter += Time.deltaTime;
    }

    private Vector3 NewPosition() {


        Vector3 Nposition = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0f);
        return Nposition;
    }

    private void CountChildren() {
        //FoodObjectCount = GetComponentsInChildren<Transform>().Length -1;
        FoodObjectCount = transform.childCount;
    }
}
