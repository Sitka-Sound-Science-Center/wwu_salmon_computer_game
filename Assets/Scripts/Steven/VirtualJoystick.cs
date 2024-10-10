using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualJoystick : MonoBehaviour
{
    [SerializeField]
    private float movespeed;
    [SerializeField]
    private Vector3 joystickPosition; // start point, will be local origin for later calculations
    [SerializeField]
    private Vector3 joystickDomePosition; // position of JSDome, the circle that represents current motion vector ie. follows finger
    [SerializeField]
    private float maxMagnitude;
    private Vector3 move;
    private Vector3 initialpos;
    private Vector3 distance;

    public Text directionText;
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private string direction;
    private float touchAngle;
    private float magnitude;

    public GameObject player;


    private void Start()
    {
            move = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Began )
            {
                touchStartPosition = theTouch.position;
                joystickPosition = theTouch.position;
            }    

            touchEndPosition = theTouch.position;

            float x = touchEndPosition.x - touchStartPosition.x;
            float y = touchEndPosition.y - touchStartPosition.y;

            Vector2 touchPosition = new Vector2(x, y);

            touchAngle = Mathf.Atan2(x, y);
            print("angle: " + touchAngle);

            //calculate distance from start point for speed
            magnitude = Vector2.Distance(touchStartPosition, touchPosition);
            if (magnitude > maxMagnitude)
            {
                magnitude = maxMagnitude;
            }
            print("magnitude: = " + magnitude);


            touchPosition.Normalize();
            print("Normalized touchPos: " + touchPosition.ToString());

            touchPosition *= magnitude*movespeed;
            transform.Translate(touchPosition);

        }
        directionText.text = direction;
    }

}
