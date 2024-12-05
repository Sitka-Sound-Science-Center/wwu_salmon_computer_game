using System.Collections;
using UnityEngine;

public class RiverCamera : MonoBehaviour
{
    private Vector3 PanEndPos;
    private bool panned = false;
    private float timer = 0F;
    [SerializeField]
    private float PanStartTime = 10F;
    [SerializeField]
    private float PanDuration = 5F;

    void Start(){
        PanEndPos = new Vector3(10,10,0);
        //transform.position+((float) Math.Sin(PanAngle)*Vector3.up)+((float)Math.Cos(PanAngle)*Vector3.right);
    }

    void Update()
    {
        if (timer<PanStartTime) timer+=Time.deltaTime;
        if (timer>=PanStartTime && !panned){
            StartCoroutine(LerpFromTo(transform.position, PanEndPos, PanDuration));
            panned=true;
        }
    }

    IEnumerator LerpFromTo(Vector3 p, Vector3 q, float duration){
        for (float t=0f; t<duration; t += Time.deltaTime) {
            transform.position = Vector3.Lerp(p, q, t / duration);
            yield return 0;
        }
        transform.position = q;
    }
}
