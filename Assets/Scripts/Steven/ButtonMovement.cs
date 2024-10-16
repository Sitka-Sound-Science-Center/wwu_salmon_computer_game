using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonMovement : MonoBehaviour
{
    float horizontalInput = 0;
    float verticalInput = 0;
    float MoveSpeed = 30;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(horizontalInput < 0)
        {
            transform.localScale = -scale;
        }
        else
        {
            transform.localScale = scale;
        }






        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * MoveSpeed * Time.deltaTime);
        float tiltAroundZ = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
        transform.SetPositionAndRotation(transform.position, target);
        // Smoothly tilts a transform towards a target rotation.
        
        // float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;


        // Rotate the cube by converting the angles into a quaternion.
        

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
