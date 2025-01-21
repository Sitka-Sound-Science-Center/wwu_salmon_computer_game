using UnityEngine;

public class PredatorMovement : MonoBehaviour
{
    [SerializeField]
    int frequency;
    [SerializeField]
    float speed;
    float xMin, xMax, yMin, yMax;
    int counter;
    GameObject Player;
    Vector3 position;
    Vector3 scaleFactor;
    EnemyFOV VisionScript;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        VisionScript = gameObject.GetComponent<EnemyFOV>();
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

    void FixedUpdate() {
        counter++;
        Vector3 NextPosition;
        bool playerVision = VisionScript.IsPlayerVisible();
        if (playerVision) {
            Vector3 DirectionToPlayer = Player.transform.position - gameObject.transform.position;
            DirectionToPlayer = Vector3.Normalize(DirectionToPlayer);
            NextPosition = transform.position + (DirectionToPlayer * speed);       
            gameObject.transform.position = new Vector3(NextPosition.x, NextPosition.y, 0);      
        }
        else if (counter > frequency) {
            //pick a random spot in the rect transform
            position = NewPosition();
            SetSpriteOrientation(position);
            counter = 0;
            //this is moving too fast on long distances
            //not actually linear speed... 
            NextPosition = Vector3.Lerp(gameObject.transform.position, position, Time.deltaTime * speed); 
            // Lerp for some reason is very slowly decreasing the z coordinate when objects need to be on the same plane
            gameObject.transform.position = new Vector3(NextPosition.x, NextPosition.y, 0);
        }
    }

    private Vector3 NewPosition()
    {
        position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
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
