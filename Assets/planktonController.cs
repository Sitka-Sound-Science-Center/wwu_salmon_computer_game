using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Android;

public class planktonController : MonoBehaviour
{
    [SerializeField]
    int maxplankton;
    [SerializeField]
    float spawndelay;
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    Vector3 position;
    int planktonCount = 0;
    int counter;
    GameObject plankton;


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
        plankton = Resources.Load<GameObject>("plankton");

    }

    // Update is called once per frame
    void Update()
    {
        if(planktonCount < maxplankton && counter > spawndelay)
        {
            //spawn a plankton
            planktonCount++;
            GameObject pebblen = Instantiate(plankton, newPosition(), Quaternion.identity,this.transform);
        }
        counter++;
    }
    private Vector3 newPosition()
    {
        position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0f);
        return position;
    }
}
