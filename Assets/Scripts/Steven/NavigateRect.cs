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
    // Start is called before the first frame update
    void Start()
    {
        rect = MoveableArea;
        agent = GetComponent<NavMeshAgent>();
        //rect = GetComponentInChildren<RectTransform>();
        float rectX = MoveableArea.rect.x + MoveableArea.position.x; //left edge of transform
        float rectY = MoveableArea.rect.y + MoveableArea.position.y; //bottom edge of transform
        Vector2 area = MoveableArea.sizeDelta;
        xMin = rectX;
        xMax = rectX + area.x;
        yMin = rectY;
        yMax = rectY + area.y;
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
        Vector3 target = new Vector3(Random.Range(rect.rect.xMin, rect.rect.xMax), 0, Random.Range(rect.rect.yMin, rect.rect.yMax));
        target.x += rect.transform.position.x;
        target.y += rect.transform.position.y;
        target.z += rect.transform.position.z;
        print(target);
        return target;
    }
}
