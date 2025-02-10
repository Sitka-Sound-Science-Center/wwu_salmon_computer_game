
using UnityEngine;


public class PredatorController : MonoBehaviour
{
    //needs to be remade and generalized.
    [SerializeField]
    int maxpredator;
    [SerializeField]
    int spawndelay;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    Vector3 position;
    int predatorCount = 0;
    int counter;
    //[SerializeField]
    //GameObject predatorsParent;
    public GameObject[] predatorsArray;
    public Camera Camera;

    // Start is called before the first frame update
    void Start()
    {
        RectTransform MoveableArea = GetComponent<RectTransform>();
        float rectX = MoveableArea.rect.x + MoveableArea.position.x; //left edge of transform
        float rectY = MoveableArea.rect.y + MoveableArea.position.y; //bottom edge of transform
        Vector2 area = MoveableArea.sizeDelta;
        xMin = rectX;
        xMax = rectX + area.x;
        yMin = rectY;
        yMax = rectY + area.y;
        //init counter to spawn delay for instant spawn of fish on scene load
        counter = spawndelay;
        //predatorsArray = predatorsParent.GetComponentsInChildren<GameObject>();
        
    }

    void Update()
    {
        if (predatorCount < maxpredator && counter > spawndelay)
        {
            //spawn a ppredator
            predatorCount++;
            //GameObject pebblen = 
            GameObject predator = Instantiate(GetPredatorObj(), NewPosition(), Quaternion.identity, this.transform);
            predator.transform.localScale = predator.transform.localScale*(Random.Range(0.5f, 1.5f));
            

            counter = 0;
        }

        CountChildren();
    }

    private void FixedUpdate()
    {
        counter++;
    }

    private Vector3 NewPosition()
    {
        position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0f);
        Vector3 viewPosition = Camera.WorldToViewportPoint(position);
        if(viewPosition.x >= 0 && viewPosition.x <= 1 && viewPosition.y >= 0 && viewPosition.y <= 1 && viewPosition.z > 0)
        {
            print("object onscreen -- skip spawn");
            position = NewPosition();
        }
        else
        {
            print("object offscreen -- spawn");
        }
        return position;
    }
    private void CountChildren()
    {
        predatorCount = transform.childCount;
    }

    private GameObject GetPredatorObj()
    {
        int randP = Random.Range(0, predatorsArray.Length);
        print(randP);
        return predatorsArray[randP];
    }

}
