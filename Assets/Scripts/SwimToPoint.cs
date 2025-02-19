using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimToPoint : MonoBehaviour
{
    public Transform objToMove;
    public Vector3[] points;

    public float speed = 15;

    private int target;
    public bool moving = false;


    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            var step = speed * Time.deltaTime;
            objToMove.position = Vector3.MoveTowards(objToMove.position, points[target], step);

            if (Vector3.Distance(objToMove.position, points[target]) < 0.001f)
            {
                if (target < points.Length-1) target++;
                else moving = false;
            }
        }
    }

    public void StartMovement()
    {
        moving = true;
        Debug.Log("starting move to point");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartMovement();
        }
    }

}
