using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualDpad : MonoBehaviour
{
    public Text directionText;
    private Touch theTouch;
    private Vector2 touchStartPosition, touchEndPosition;
    private string direction;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Began )
            {
                touchStartPosition = theTouch.position;
            }    
            else if (theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;

                float x = touchEndPosition.x - touchStartPosition.x;
                float y = touchEndPosition.y - touchStartPosition.y;

                if(Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
                {
                    direction = "Tapped";
                }
                else if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    direction = x > 0 ? RightMovement() : LeftMovement();
                }
                else
                {
                    direction = y > 0 ? UpMovement() : DownMovement();
                }
            }
        }
        directionText.text = direction;
    }

    private string RightMovement()
    {
        transform.Translate(1, 0, 0);
        return "Right";
    }
    private string LeftMovement()
    {
        transform.Translate(-1, 0, 0);

        return "Left";
    }

    private string UpMovement()
    {
        transform.Translate(0, 1, 0);
        return "Up";
    }

    private string DownMovement()
    {
        transform.Translate(0, -1, 0);
        return "Down";
    }
}
