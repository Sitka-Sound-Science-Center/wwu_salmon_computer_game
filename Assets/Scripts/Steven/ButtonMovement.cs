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

        float tiltAroundZ = Mathf.Atan2(verticalInput, horizontalInput) * Mathf.Rad2Deg;
        print(tiltAroundZ);
        

        if (horizontalInput < 0)
        {
            Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ-180);
            transform.localScale = new Vector3 (-scale.x, scale.y, scale.z);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * MoveSpeed * Time.deltaTime);
        }
        else if (horizontalInput > 0)
        {
            Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);
            transform.localScale = scale;
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * MoveSpeed * Time.deltaTime);
        }
        else {

                transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * MoveSpeed * Time.deltaTime);
            }
        //transform.SetPositionAndRotation(transform.position, target);
        // Smoothly tilts a transform towards a target rotation.
        
        // float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;


        // Rotate the cube by converting the angles into a quaternion.
        

        // Dampen towards the target rotation
        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
