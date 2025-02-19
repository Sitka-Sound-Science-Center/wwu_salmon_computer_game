using UnityEngine;

public class PredatorController : MonoBehaviour
{   
    // Public: 
    [SerializeField]
    int maxpredator;
    [SerializeField]
    int spawndelay;
    public GameObject[] predatorsArray;
    public Camera Camera;
    // Private: 
    Vector3 position;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    int predatorCount = 0;
    int counter;

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
        // init counter to spawn delay for instant spawn of fish on scene load
        counter = spawndelay;
    }

    void Update() {
        if (predatorCount < maxpredator && counter > spawndelay) { 
            // spawn a predator after (spawndelay) fixed updates
            predatorCount++;
            GameObject predator = Instantiate(GetPredatorObj(), NewPosition(), Quaternion.identity, this.transform);
            predator.transform.localScale = predator.transform.localScale*(Random.Range(0.5f, 1.5f));
            counter = 0;
        }
        //print("Predator count: " + predatorCount + " Transform children: " + gameObject.transform.childCount);
    }

    private void FixedUpdate() {
        counter++;
    }

    private Vector3 NewPosition() {
        position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0f);
        Vector3 viewPosition = Camera.WorldToViewportPoint(position);
        if(viewPosition.x >= 0 && viewPosition.x <= 1 && viewPosition.y >= 0 && viewPosition.y <= 1 && viewPosition.z > 0) {
            position = NewPosition();
        }
        return position;
    }

    private GameObject GetPredatorObj() {
        int randP = Random.Range(0, predatorsArray.Length);
        return predatorsArray[randP];
    }

}
