using UnityEngine;


public class PredatorController : MonoBehaviour
{
    //needs to be remade and generalized.
    [SerializeField]
    int maxpredator;
    [SerializeField]
    float spawndelay;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    Vector3 position;
    int planktonCount = 0;
    int counter;
    [SerializeField]
    GameObject predator;


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
    }

    void Update()
    {
        if (planktonCount < maxpredator && counter > spawndelay)
        {
            //spawn a plankton
            planktonCount++;
            GameObject pebblen = Instantiate(predator, NewPosition(), Quaternion.identity, this.transform);
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
        return position;
    }

    private void CountChildren()
    {
        planktonCount = GetComponentsInChildren<Transform>().Length - 1;
    }
}
