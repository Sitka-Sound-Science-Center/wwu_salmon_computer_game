
using UnityEngine;

public class planktonMovement : MonoBehaviour
{
    [SerializeField]
    int frequency;
    [SerializeField]
    float speed;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    public Vector3 newPosition;
    int counter;
    public float movementRange;

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
        counter = frequency * 2;
        newPosition = this.transform.position;
        //print("Starting Position for: " + this.name + " is: " + this.transform.position);
    }

    void FixedUpdate()
    {
        counter++;
        if (counter > UnityEngine.Random.Range(frequency / 2, frequency * 2))
        {
            //pick a random spot in the rect transform
            this.newPosition = NewPosition();
            counter = 0;
        }

        
        this.transform.position = new Vector3 (Mathf.SmoothStep(this.transform.position.x, this.newPosition.x, speed), Mathf.SmoothStep(this.transform.position.y, this.newPosition.y, speed), 0f);
        //this is moving too fast on long distances
        //not actauly linear speed... 
    }

    //private Vector3 NewPosition()
    //{
    //    position = new Vector3(UnityEngine.Random.Range(xMin, xMax), UnityEngine.Random.Range(yMin, yMax), 0f);
    //    return position;
    //}

    private Vector3 NewPosition()
    {
        float newX = Mathf.Clamp((this.transform.position.x + (Random.Range(-movementRange, movementRange) * 2)), xMin, xMax);
        float newY = Mathf.Clamp((this.transform.position.y + (Random.Range(-movementRange, movementRange))), yMin, yMax);
        //print("newCoord: " + newX + ", " + newY);
        //newPosition = new Vector3(newX, new YieldIn)
        //position = new Vector3(0f, 0f, 0f);
        return new Vector3(newX, newY, 0f); ;
    }
}
