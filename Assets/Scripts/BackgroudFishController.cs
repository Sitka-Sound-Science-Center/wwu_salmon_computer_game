
using UnityEngine;


public class BackgroudFishController : MonoBehaviour
{
    public int frequency = 400;
    public int movementRange = 200;
    public float speed = 0.02f;
    private float xMin;
    private float yMin;
    private float xMax;
    private float yMax;
    private Vector3[] fourCorners = new Vector3[4];
    private int counter;
    private Vector3 newPosition;
    private Quaternion spriteDirection;

    // Start is called before the first frame update
    void Start()
    {
        counter = frequency;
        RectTransform moveableArea = GetComponentInParent<RectTransform>();
        moveableArea.GetWorldCorners(fourCorners);
        xMin = fourCorners[0].x;
        xMax = fourCorners[2].x;
        yMin = fourCorners[0].y;
        yMax = fourCorners[2].y;

        //Debug.Log("Y VALS: " + yMin + " " + yMax);
    }

    private void FixedUpdate()
    {
        counter++;
        if (counter > Random.Range(frequency / 2, frequency * 2))
        {
            //pick a random spot in the rect transform
            this.newPosition = NewPosition();
            counter = 0;
        }
        //this.transform.rotation = Quaternion.LookRotation(newPosition, new Vector3(0,0,1));
        this.transform.position = new Vector3(Mathf.SmoothStep(this.transform.position.x, this.newPosition.x, speed), Mathf.SmoothStep(this.transform.position.y, this.newPosition.y, speed), 0f);


    }
    private Vector3 NewPosition()
    {
        float newX = Mathf.Clamp((this.transform.position.x + (Random.Range(-movementRange, movementRange) * 2)), xMin, xMax);
        float newY = Mathf.Clamp((this.transform.position.y + (Random.Range(-movementRange, movementRange))), yMin, yMax);
        // print("newCoord: " + newX + ", " + newY);
        //newPosition = new Vector3(newX, new YieldIn)
        //position = new Vector3(0f, 0f, 0f);
        return new Vector3(newX, newY, 0f); ;
    }

    //private Quaternion getSpriteDirection(Vector3 position)
    //{


    //    return spriteDirection;
    //}
}
