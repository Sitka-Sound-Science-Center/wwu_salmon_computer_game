using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigateRect : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private RectTransform MoveableArea;
    [SerializeField]
    private float MoveInterval;
    private float timePassed;
    private float xMin;
    private float yMin;
    private float xMax;
    private float yMax;
    private RectTransform rect;
    private Vector3[] fourCorners = new Vector3[4];

    // Start is called before the first frame update
    void Start()
    {
        rect = MoveableArea;
        agent = GetComponent<NavMeshAgent>();
        //rect = GetComponentInChildren<RectTransform>();
        float rectX = MoveableArea.rect.x + MoveableArea.position.x; //left edge of transform
        float rectY = MoveableArea.rect.y + MoveableArea.position.y; //bottom edge of transform
        Vector2 area = MoveableArea.sizeDelta;
        
        MoveableArea.GetWorldCorners(fourCorners);
        xMin = fourCorners[0][0];
        xMax = fourCorners[2][0];
        yMin = fourCorners[0][2];
        yMax = fourCorners[2][2];

        print("rectCorners: xMin: " + xMin + " xMax: " + xMax + " yMin: " + yMin + " yMax: " + yMax);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > MoveInterval)
        {
            //do stuff
            agent.SetDestination(GetPoint(rect));
            timePassed = 0f;
        }
    }

    private Vector3 GetPoint(RectTransform rect)
    {
        Vector3 target = new Vector3(Random.Range(xMin,xMax), 0, Random.Range(yMin,yMax));
        print(target);
        return target;
    }
}
