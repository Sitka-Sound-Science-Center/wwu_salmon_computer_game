using UnityEngine;

public class PredatorMovement : MonoBehaviour
{
    [SerializeField]
    int frequency;
    [SerializeField]
    float speed;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    Vector3 position;
    int counter;
    Vector3 scaleFactor;

    void Start()
    {
        counter = frequency;
        RectTransform MoveableArea = GetComponentInParent<RectTransform>();
        float rectX = MoveableArea.rect.x + MoveableArea.position.x; //left edge of transform
        float rectY = MoveableArea.rect.y + MoveableArea.position.y; //bottom edge of transform
        Vector2 area = MoveableArea.sizeDelta;
        xMin = rectX;
        xMax = rectX + area.x;
        yMin = rectY;
        yMax = rectY + area.y;
        scaleFactor = transform.localScale;
    }

    void FixedUpdate()
    {
        counter++;
        if (counter > frequency)
        {
            //pick a random spot in the rect transform
            position = NewPosition();
            SetSpriteOrientation(position);

            counter = 0;
        }

        transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime * speed);
        //this is moving too fast on long distances
        //not actually linear speed... 
    }

    private Vector3 NewPosition()
    {
        position = new Vector3(Random.Range(xMin, xMax), this.transform.position.y, 0f);
        return position;
    }

    private void SetSpriteOrientation(Vector3 position)
    {
        if (position.x < transform.position.x)
        {
            //face sprite to the right
            transform.localScale = new Vector3(scaleFactor.x, scaleFactor.y, scaleFactor.z);
        }
        else
        {
            //face sprite to the left
            transform.localScale = new Vector3(-scaleFactor.x, scaleFactor.y, scaleFactor.z);
        }
    }
}
