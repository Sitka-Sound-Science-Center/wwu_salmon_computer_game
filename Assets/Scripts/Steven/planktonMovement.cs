using UnityEngine;

public class planktonMovement : MonoBehaviour
{
    [SerializeField]
    float frequency;
    [SerializeField]
    float speed;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    Vector3 position;
    int counter;

    void Start()
    {
        RectTransform MoveableArea = GetComponentInParent<RectTransform>();
        float rectX = MoveableArea.rect.x + MoveableArea.position.x; //left edge of transform
        float rectY = MoveableArea.rect.y + MoveableArea.position.y; //bottom edge of transform
        Vector2 area = MoveableArea.sizeDelta;
        xMin = rectX;
        xMax = rectX + area.x;
        yMin = rectY;
        yMax = rectY + area.y;
    }

    void FixedUpdate()
    {
        counter++;
        if (counter > frequency)
        {
            //pick a random spot in the rect transform
            position = NewPosition();
            counter = 0;
        }

        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * speed);
        //this is moving too fast on long distances
        //not actauly linear speed... 
    }

    private Vector3 NewPosition()
    {
        position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0f);
        return position;
    }
}
