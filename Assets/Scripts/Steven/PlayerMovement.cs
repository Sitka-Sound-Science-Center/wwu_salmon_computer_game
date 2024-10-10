using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 MoveVector = new (0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveVector);
    }

    public void moveLeft()
    {
        MoveVector = new (-1, 0, 0);
    }

    public void moveRight()
    {
        MoveVector = new(1, 0, 0);
    }

    public void moveUp() {
        MoveVector = new(0, 1, 0);

    }

    public void moveDown()
    {
        MoveVector = new(0, -1, 0);
    }
    public void cancelMove()
    {
        MoveVector = Vector3.zero;

    }
}
