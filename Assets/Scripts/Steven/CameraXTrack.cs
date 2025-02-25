using UnityEngine;

public class CameraXTrack : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    float fryHeight;

    public bool trackY;
    public bool boundX;
    public float topBound;
    public float lowBound;
    public float leftBound;
    public float rightBound;
    public float yStart;
 
    void Update()
    {
        float yPos = this.transform.position.y;
        float xPos = Mathf.Lerp(transform.position.x, Player.transform.position.x, 0.75f);
        if (trackY)
        {
            yPos = Mathf.Lerp(transform.position.y, Player.transform.position.y, 0.75f);
            yPos = Mathf.Clamp(yPos+yStart, lowBound, topBound);
        }
        if (boundX)
        {
            xPos = Mathf.Clamp(xPos, leftBound, rightBound);
        }
        this.transform.position = new Vector3(xPos, yPos, this.transform.position.z);   
    }

    public void ChangeToFryPosition()
    {
        this.transform.position = new Vector3(this.transform.position.x, Mathf.Lerp(transform.position.y, transform.position.y + fryHeight, 0.75f), this.transform.position.z);
    }
}
