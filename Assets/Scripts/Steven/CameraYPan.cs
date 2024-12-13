using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CameraYPan : MonoBehaviour
{
    [SerializeField]
    RectTransform rectTransform;
    [SerializeField]
    Camera cam;
    [SerializeField]
    bool useOffset;
    private Vector3 camPos;
    private Quaternion camRot;
    
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    float rectOffset;
    
    void Start()
    {
        rectOffset = GameObject.Find("CameraYPanner").GetComponent<RectTransform>().sizeDelta.y;
        print(name + ":  " + rectOffset);
        camPos = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);

        //left edge of transform
        float rectX = GetComponent<RectTransform>().rect.x + GetComponent<RectTransform>().position.x;
        //bottom edge of transform
        float rectY = GetComponent<RectTransform>().rect.y + GetComponent<RectTransform>().position.y;

        Vector2 area = GetComponent<RectTransform>().sizeDelta;
        xMin = rectX;
        xMax = rectX + area.x;
        yMin = rectY;
        yMax = rectY + area.y;
    }

    void Update()
    {
        if( cam.transform.position.x > xMin && cam.transform.position.x < xMax)
        {
            float x1 = cam.transform.position.x - xMin;
            float y2 = yMax - yMin;
            float x2 = xMax - xMin;
            camPos.x = cam.transform.position.x;
            camPos.y = (x1 * y2) / x2;
            if (useOffset)
            {
                camPos.y += rectOffset;
            }
            cam.transform.SetPositionAndRotation(camPos, camRot);
        }
    }
}
