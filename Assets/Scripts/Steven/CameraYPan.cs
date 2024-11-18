
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
    
    private bool firstEntry = true;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;

    float rectOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        rectOffset = GameObject.Find("CameraYPanner").GetComponent<RectTransform>().sizeDelta.y;
        print(this.name + ":  " + rectOffset);
        camPos = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);

        float rectX = this.GetComponent<RectTransform>().rect.x + this.GetComponent<RectTransform>().position.x; //left edge of transform
        float rectY = this.GetComponent<RectTransform>().rect.y + this.GetComponent<RectTransform>().position.y; //bottom edge of transform
        Vector2 area = this.GetComponent<RectTransform>().sizeDelta;
        xMin = rectX;
        xMax = rectX + area.x;
        yMin = rectY;
        yMax = rectY + area.y;
    }

    // Update is called once per frame
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
  
        
    }
}
