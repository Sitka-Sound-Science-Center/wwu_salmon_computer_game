using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 MoveVector = new (0,0,0);
    [SerializeField]
    float MoveSpeed = 30;
    float horizontalInput = 0;
    float verticalInput = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * MoveSpeed * Time.deltaTime);
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");
    }

    public void moveLeft()
    {
        horizontalInput = -1;
        
    }

    public void moveRight()
    {
        horizontalInput = 1;
    }

    public void moveUp() {
        verticalInput = 1;

    }

    public void moveDown()
    {
        verticalInput = -1;
    }
    public void cancelMove()
    {
        horizontalInput = 0;
        verticalInput = 0;

    }
}
