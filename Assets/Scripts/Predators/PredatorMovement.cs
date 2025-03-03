using UnityEngine;

public class PredatorMovement : MonoBehaviour
{
    // Public: 
    [SerializeField]
    float DirectionFrequency; // duration between direction change
    [SerializeField]
    int VisionFrequency; // how many fixed updates to wait before checking vision cone
    [SerializeField]
    float speed; // units to move every second
    public Vector3 Direction;
    // Private: 
    GameObject Player;
    EnemyFOV VisionScript;
    Vector3 position;
    Vector3 scaleFactor;
    float DirectionTimer;
    float xMin, xMax, yMin, yMax;
    int counter;
    bool PlayerVision;

    void Start() {
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

    Vector3 RejectionSample() {
        Vector3 dir;
        while (true) {
            position = NewPosition();
            dir = Vector3.Normalize(position - gameObject.transform.position);
            bool bottom = dir.y < 0 && Vector3.Angle(dir, Vector3.Down) > 10F;
            bool top = dir.y > 0 && Vector3.Angle(dir, Vector3.Up) > 10F;
            if (bottom && top) break;   
        }
        return dir;
    }

    void FixedUpdate() {
        counter++;
        if (counter>VisionFrequency) {
            PlayerVision = VisionScript.IsPlayerVisible();
            counter = 0; 
        }
    }

    private Vector3 NewPosition() {
        position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
        return position;
    }

    public void SetSpriteOrientation(Vector3 dir)
    {
        if (dir.x < 0) {
            //face sprite to the left
            gameObject.transform.localScale = new Vector3(-scaleFactor.x, scaleFactor.y, scaleFactor.z);
        }
        else {
            //face sprite to the right
            gameObject.transform.localScale = new Vector3(scaleFactor.x, scaleFactor.y, scaleFactor.z);
        }
        float orientation = (gameObject.transform.localScale.x < 0) ? -1 : 1;
        float angle = Vector3.SignedAngle(Vector3.right, dir, Vector3.forward);
        if (orientation < 0) angle = -(180 - angle);
        gameObject.transform.eulerAngles = new Vector3(0,0, angle);
    }
}