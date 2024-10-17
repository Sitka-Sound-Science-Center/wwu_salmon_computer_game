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

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * MoveSpeed * Time.deltaTime);
    }
}
