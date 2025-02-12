using UnityEngine;

public class PredatorMovement : MonoBehaviour
{
    [SerializeField]
    float DirectionFrequency; // duration between direction change
    [SerializeField]
    int VisionFrequency; // how many fixed updates to wait before checking vision cone
    [SerializeField]
    float speed; // units to move every second
    public Vector3 Direction;
    float DirectionTimer;
    float xMin, xMax, yMin, yMax;
    int counter;
    bool PlayerVision;
    GameObject Player;
    Vector3 position;
    Vector3 scaleFactor;
    EnemyFOV VisionScript;

    void Start()
    {
        PlayerVision = false;
        Player = GameObject.FindWithTag("Player");
        Direction = Vector3.left;
        VisionScript = gameObject.GetComponent<EnemyFOV>();
        counter = 0;
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

    void Update() {
        DirectionTimer+=Time.deltaTime;
        // Pick a new direction to move in every (DirectionFrequency) seconds
        if (DirectionTimer >= DirectionFrequency && !PlayerVision) {
            DirectionTimer=0;
            //pick a random spot in the rect transform
            position = NewPosition();
            Direction = Vector3.Normalize(position - gameObject.transform.position);
            SetSpriteOrientation(Direction);
        }
        else if (PlayerVision) {
            Direction = Vector3.Normalize(Player.transform.position - gameObject.transform.position);   
            SetSpriteOrientation(Direction); 
        }
        // speed is set reasonably high so movement looks and feels smooth
        gameObject.transform.position += (Direction * Time.deltaTime * speed); 
    }

    void FixedUpdate() {
        counter++;
        if (counter>VisionFrequency) {
            PlayerVision = VisionScript.IsPlayerVisible();
            counter = 0; 
        }
    }

    private Vector3 NewPosition()
    {
        position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
        return position;
    }

    private void SetSpriteOrientation(Vector3 dir)
    {
        if (dir.x < 0)
        {
            //face sprite to the left
            gameObject.transform.localScale = new Vector3(-scaleFactor.x, scaleFactor.y, scaleFactor.z);
        }
        else
        {
            //face sprite to the right
            gameObject.transform.localScale = new Vector3(scaleFactor.x, scaleFactor.y, scaleFactor.z);
        }
        float orientation = (gameObject.transform.localScale.x < 0) ? -1 : 1;
        float angle = Vector3.SignedAngle(Vector3.right, Direction, Vector3.forward);
        print("Signed Angle: " + angle + " Orientation: " + orientation + " Predator: " + gameObject.name);
        if (orientation < 0) angle = -(180 - angle);
        //else angle = -angle;
        //print("orientation: " + orientation + " Angle: " + angle + " " + gameObject.name);
        gameObject.transform.eulerAngles = new Vector3(0,0, angle);
    }
}
