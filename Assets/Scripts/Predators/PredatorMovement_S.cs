using UnityEngine;
using UnityEngine.AI;

public class PredatorMovement_S : MonoBehaviour
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
    EnemyFOV_S VisionScript;
    Vector3 position;
    Vector3 scaleFactor;
    float DirectionTimer;
    float xMin, xMax, yMin, yMax;
    int counter;
    bool PlayerVision;
    NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        PlayerVision = false;
        Player = GameObject.FindWithTag("Player");
        Direction = Vector3.right;
        VisionScript = gameObject.GetComponent<EnemyFOV_S>();
        counter = VisionFrequency;
        RectTransform MoveableArea = GetComponentInParent<RectTransform>();
        float rectX = MoveableArea.rect.x + MoveableArea.position.x; //left edge of transform
        float rectY = MoveableArea.rect.y + MoveableArea.position.y; //bottom edge of transform
        Vector2 area = MoveableArea.sizeDelta;
        xMin = rectX;
        xMax = rectX + area.x;
        yMin = rectY;
        yMax = rectY + area.y;
        scaleFactor = transform.localScale;
        position = NewPosition();
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
            agent.SetDestination(position);
        }
        else if (PlayerVision) {
            Direction = Vector3.Normalize(Player.transform.position - gameObject.transform.position);   
            SetSpriteOrientation(Direction);
            agent.SetDestination(Player.transform.position);
        }
        // speed is set reasonably high so movement looks and feels smooth
        transform.SetPositionAndRotation(transform.position, Quaternion.identity);

    }

    void FixedUpdate() {
        counter++;
        if (counter>VisionFrequency) {
            PlayerVision = VisionScript.IsPlayerVisible();
            counter = 0; 
        }
    }

    private Vector3 NewPosition() {
        position = new Vector3(Random.Range(xMin, xMax), 0, Random.Range(yMin, yMax));
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