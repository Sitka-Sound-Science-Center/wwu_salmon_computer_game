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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(horizontalInput, verticalInput,0) * MoveSpeed * Time.deltaTime);
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Mathf.Atan2(horizontalInput, verticalInput) * Mathf.Rad2Deg;
        // float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;


        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }
}
